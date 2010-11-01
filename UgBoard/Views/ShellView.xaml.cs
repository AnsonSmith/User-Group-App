namespace UgBoard.Views
{
    using System.Windows;
    using System.Xml;
    using System.Text;
     using System.Windows.Markup;
    using System.Windows.Controls;
    using System;
    using System.Reflection;

    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
            

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = new string(' ', 4);
            settings.NewLineOnAttributes = true;
            StringBuilder strbuild = new StringBuilder();
            XmlWriter xmlwrite = XmlWriter.Create(strbuild, settings);
            XamlWriter.Save(this.LeftColumn.Template, xmlwrite);

            int i = 99;
            i++;
            
        }

        //Ugly Hack, may be a better way to do this
        private void LeftColumn_Loaded(object sender, RoutedEventArgs e)
        {
            TransitioningContentControl transCont = sender as TransitioningContentControl;
            Type t = transCont.GetType();
            FieldInfo f = t.GetField("<CurrentContentPresentationSite>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
            ContentPresenter contPres = f.GetValue(transCont) as ContentPresenter;
            contPres.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            contPres.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        }
    }
}
