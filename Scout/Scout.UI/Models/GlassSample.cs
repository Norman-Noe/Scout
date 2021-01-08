using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Scout.UI.Models
{
    public class GlassSample : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region ---- PROPERTIES ----

        private string label;
        public string Label
        {
            get { return label; }
            set { label = value; OnPropertyChanged("Id"); }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; OnPropertyChanged("Company"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private string category;
        public string Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged("Category"); }
        }

        private string glassBase01;
        public string GlassBase01
        {
            get { return glassBase01; }
            set { glassBase01 = value; OnPropertyChanged("GlassBase01"); }
        }

        private string baseSpec01;
        public string BaseSpec01
        {
            get { return baseSpec01; }
            set { baseSpec01 = value; OnPropertyChanged("BaseSpec01"); }
        }

        private string glassThickness01;
        public string GlassThickness01
        {
            get { return glassThickness01; }
            set { glassThickness01 = value; OnPropertyChanged("GlassThickness01"); }
        }


        private string glassBase02;
        public string GlassBase02
        {
            get { return glassBase02; }
            set { glassBase02 = value; OnPropertyChanged("GlassBase02"); }
        }

        private string baseSpec02;
        public string BaseSpec02
        {
            get { return baseSpec02; }
            set { baseSpec02 = value; OnPropertyChanged("BaseSpec02"); }
        }

        private string glassThickness02;
        public string GlassThickness02
        {
            get { return glassThickness02; }
            set { glassThickness02 = value; OnPropertyChanged("GlassThickness02"); }
        }


        private string glassBase03;
        public string GlassBase03
        {
            get { return glassBase03; }
            set { glassBase03 = value; OnPropertyChanged("GlassBase03"); }
        }

        private string baseSpec03;
        public string BaseSpec03
        {
            get { return baseSpec03; }
            set { baseSpec03 = value; OnPropertyChanged("BaseSpec03"); }
        }

        private string glassThickness03;
        public string GlassThickness03
        {
            get { return glassThickness03; }
            set { glassThickness03 = value; OnPropertyChanged("GlassThickness03"); }
        }

        private string coating01;
        public string Coating01
        {
            get { return coating01; }
            set { coating01 = value; OnPropertyChanged("Coating01"); }
        }

        private int coatingSurfacce01;
        public int CoatingSurface01
        {
            get { return coatingSurfacce01; }
            set { coatingSurfacce01 = value; OnPropertyChanged("CoatingSurface01"); }
        }

        private string coating02;
        public string Coating02
        {
            get { return coating02; }
            set { coating02 = value; OnPropertyChanged("Coating02"); }
        }

        private int coatingSurfacce02;
        public int CoatingSurface02
        {
            get { return coatingSurfacce02; }
            set { coatingSurfacce02 = value; OnPropertyChanged("CoatingSurface02"); }
        }

        private string surfaceModif;
        public string SurfaceModif
        {
            get { return surfaceModif; }
            set { surfaceModif = value; OnPropertyChanged("SurfaceModif"); }
        }
        private string lamination;
        public string Lamination
        {
            get { return lamination; }
            set { lamination = value; OnPropertyChanged("Lamination"); }
        }

        private double transmittance;
        public double Transmittance
        {
            get { return transmittance; }
            set { transmittance = value; OnPropertyChanged("Transmittance"); }
        }

        private double reflectiveExt;
        public double ReflectiveExt
        {
            get { return reflectiveExt; }
            set { reflectiveExt = value; OnPropertyChanged("ReflectiveExt"); }
        }

        private double reflectiveInt;
        public double ReflectiveInt
        {
            get { return reflectiveInt; }
            set { reflectiveInt = value; OnPropertyChanged("ReflectiveInt"); }
        }

        private double uValue;
        public double UValue
        {
            get { return uValue; }
            set { uValue = value; OnPropertyChanged("UValue"); }
        }

        private double shgc;
        public double SHGC
        {
            get { return shgc; }
            set { shgc = value; OnPropertyChanged("SHGC"); }
        }

        private double lsg;
        public double LSG
        {
            get { return lsg; }
            set { lsg = value; OnPropertyChanged("LSG"); }
        }

        private Attachment attachment;
        public Attachment Attachment
        {
            get { return attachment; }
            set { attachment = value; OnPropertyChanged("Attachment"); }
        }

        private string sampleDimensions;
        public string SampleDimensions
        {
            get { return sampleDimensions; }
            set { sampleDimensions = value; OnPropertyChanged("SampleDimensions"); }
        }

        private bool checkedOut;
        public bool CheckedOut
        {
            get { return checkedOut; }
            set { checkedOut = value; OnPropertyChanged("CheckedOut"); }
        }

        private string projectNumber;
        public string ProjectNumber
        {
            get { return projectNumber; }
            set { projectNumber = value; OnPropertyChanged("ProjectNumber"); }
        }

        private string projectManager;
        public string ProjectManager
        {
            get { return projectManager; }
            set { projectManager = value; OnPropertyChanged("ProjectManager"); }
        }

        #endregion


        #region ---- CONSTRUCTORS ----


        public GlassSample() { }




        #endregion
    }
