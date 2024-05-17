/// <Summary>
/// ロガー用クラス
/// ログ種別によっては静的ファイルだけでなく、GUI画面にも出す。
/// 設定はAppConfig.jsonのLOGセクションに記載
/// https://qiita.com/yun_bow/items/24f38179d1e92c9b7fd3
/// </Summary> 
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PAMC_104
{
    public class Logger
    {
        protected readonly object lockObj = new object();
        protected StreamWriter stream = null;
        protected readonly string logDirectoryPath = null;
        protected readonly string logFileName = null;
        protected readonly string logFilePath = null;  // ログファイルのフルパス(./Logs/console.log)
        private static Logger _instance = null;
        private int LOG_LEVEL = 3;

        /// <summary>
        /// ログレベル
        /// </summary>
        private enum LogLevel
        {
            ERROR,
            WARN,
            INFO,
            NOTICE
        }

        private MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault(); // MainFormへのアクセス用

        /// <summary>
        /// インスタンスを生成する
        /// シングルトンパターンとし、最初の初期化時のみ設定読み込みを行う。
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }

        public Logger()
        {
            logDirectoryPath = ".\\Logs\\";
            logFileName = "console";

            this.logFilePath = logDirectoryPath + logFileName + ".log";
            CreateLogfile(new FileInfo(logFilePath));
        }

        /// <summary>
        /// ERRORレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Error(string msg)
        {
            if ((int)LogLevel.ERROR <= LOG_LEVEL)
            {
                Out(LogLevel.ERROR, msg);
            }
        }

        /// <summary>
        /// ERRORレベルのスタックトレースログを出力する
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        public void Error(Exception ex)
        {
            if ((int)LogLevel.ERROR <= LOG_LEVEL)
            {
                Out(LogLevel.ERROR, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        /// <summary>
        /// WARNレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Warn(string msg)
        {
            if ((int)LogLevel.WARN <= LOG_LEVEL)
            {
                Out(LogLevel.WARN, msg);
            }
        }

        /// <summary>
        /// INFOレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Info(string msg)
        {
            if ((int)LogLevel.INFO <= LOG_LEVEL)
            {
                Out(LogLevel.INFO, msg);
            }
        }

        /// <summary>
        /// NOTICEレベルのログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public void Notice(string msg)
        {
            if ((int)LogLevel.NOTICE <= LOG_LEVEL)
            {
                Out(LogLevel.NOTICE, msg);
            }
        }

        /// <summary>
        /// ログを出力する
        /// </summary>
        /// <param name="level">ログレベル</param>
        /// <param name="msg">メッセージ</param>
        private void Out(LogLevel level, string msg)
        {
            int tid = System.Threading.Thread.CurrentThread.ManagedThreadId;
            string fullMsg = string.Format("[{0}][{1}][{2}] {3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), tid, level.ToString(), msg);

            lock (this.lockObj)
            {
                // 1. ログファイルへの書き出し
                this.stream.WriteLine(fullMsg);

                // 2. GUIのテキストボックスへの書き出し
                // ログラベル：ERROR, WARN, NOTICEがログとして出る
                if (level == LogLevel.ERROR || level == LogLevel.NOTICE || level == LogLevel.WARN)
                {
                    //TODO:ここうまく動かない
                    //mainForm.AppendGUILog(fullMsg);
                }

                // 3. ファイルサイズ検証とログローテーション
                CheckAndManageLogFileSize();
            }
        }



        // ログの管理に関するメソッド群
        /// <summary>
        /// ログファイルのサイズに応じてアーカイブ化や削除などの処理を行う
        /// </summary>
        protected void CheckAndManageLogFileSize()
        {
            FileInfo logFile = new FileInfo(this.logFilePath);
            long maxLogFileSize = 10485760;

            if (logFile.Length >= maxLogFileSize)
            {
                // ログファイルを圧縮する
                CompressLogFile();

                // 古いログファイルを削除する
                DeleteOldLogFile();
            }
        }

        /// <summary>
        /// ログファイルを生成する
        /// </summary>
        /// <param name="logFile">ファイル情報</param>
        protected void CreateLogfile(FileInfo logFile)
        {
            if (!Directory.Exists(logFile.DirectoryName))
            {
                Directory.CreateDirectory(logFile.DirectoryName);
            }

            this.stream = new StreamWriter(logFile.FullName, true, Encoding.UTF8)
            {
                AutoFlush = true
            };
        }


        /// <summary>
        /// ログファイルをZIP形式に圧縮する
        /// 圧縮対象のファイルを_yyyyMMddHHmmss形式のタイムスタンプ付にリネームしZIP圧縮
        /// </summary>
        protected void CompressLogFile()
        {
            this.stream.Close(); // 書き出し用ストリームを閉じる

            // 現行のファイルを名前変えてアーカイブ化
            string oldFilePath = logDirectoryPath + logFileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            File.Move(this.logFilePath, oldFilePath + ".log");

            using (FileStream originalFileStream = new FileStream(oldFilePath + ".log", FileMode.Open, FileAccess.Read))
            {
                using (FileStream compressedFileStream = new FileStream(oldFilePath + ".zip", FileMode.Create, FileAccess.Write))
                {
                    using (ZipArchive archive = new ZipArchive(compressedFileStream, ZipArchiveMode.Create, true))
                    {
                        ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(oldFilePath + ".log"));
                        using (Stream entryStream = entry.Open())
                        {
                            originalFileStream.CopyTo(entryStream);
                        }
                    }
                }
            }

            File.Delete(oldFilePath + ".log"); // ZIP圧縮前の原本を削除

            CreateLogfile(new FileInfo(this.logFilePath)); // 新たにアクティブなログファイルを作成
        }

        /// <summary>
        /// 古いログファイルを削除する
        /// </summary>
        protected void DeleteOldLogFile()
        {
            Regex regex = new Regex(logFileName + @"_(\d{14}).*\.gz");
            DateTime retentionDate = DateTime.Today.AddDays(-30); // 30日でアーカイブ
            string[] filePathList = Directory.GetFiles(logDirectoryPath, logFileName + "_*.gz", SearchOption.TopDirectoryOnly);
            foreach (string filePath in filePathList)
            {
                Match match = regex.Match(filePath);
                if (match.Success)
                {
                    DateTime logCreatedDate = DateTime.ParseExact(match.Groups[1].Value.ToString(), "yyyyMMddHHmmss", null);
                    if (logCreatedDate < retentionDate)
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }
    }
}