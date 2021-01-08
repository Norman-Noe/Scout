using System;
using System.Collections.Generic;
using System.Text;

namespace Scout.UI.Models
{
    public class GlassSampleService
    {

        #region ---- PROPERTIES ----

        private static List<GlassSample> GlassSamples;

        #endregion


        #region ---- CONSTRUCTORS ----

        public GlassSampleService()
        {
            GlassSamples = new List<GlassSample>();
        }

        #endregion


        #region ---- FUNCTIONS ----

        public List<GlassSample> GetAll()
        {
            return GlassSamples;
        }

        public bool AddSample(GlassSample NewGlassSample)
        {

            return true;
        }

        #endregion

    }
}
