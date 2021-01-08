using System;
using System.Collections.Generic;
using System.Text;

namespace Scout.UI.Models
{
    public class Attachment
    {

        #region ---- PROPERTIES ----

        public byte[] Bytes { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        #endregion

        #region ---- CONSTRUCTORS ----

        public Attachment() { }

        public Attachment(string FileName, string FilePath, byte[] Bytes)
        {
            this.FileName = FileName;
            this.FilePath = FilePath;
            this.Bytes = Bytes;
        }

        #endregion

    }
}
