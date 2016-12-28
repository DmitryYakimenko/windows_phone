using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using windows_phone.articles;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Windows.UI.Xaml.Media.Imaging;





// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=391641

namespace windows_phone
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            
            
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Подготовьте здесь страницу для отображения.
            //192.168.1.38
            //94.76.95.74
            var uri = new Uri("http://192.168.1.38/api/");
            var client = new HttpClient();
            string result = await client.GetStringAsync(uri);


            

            Articles articales = JsonConvert.DeserializeObject<Articles>(result);

            foreach (var a in articales.articles)
            {
                
                PivotItem pi = new PivotItem();

                ScrollViewer sw = new ScrollViewer();
                ListView lw = new ListView();
                sw.Content = lw;
                lw.IsItemClickEnabled = false;
                lw.IsTextScaleFactorEnabled = true;


                pi.Content = (sw);

                Image image = new Image();
                BitmapImage bi3 = new BitmapImage();
                bi3.UriSource = new Uri(a.image);
                image.Stretch = Stretch.Fill;
                image.Source = bi3;


                TextBlock details = new TextBlock();
                details.IsTapEnabled = false;
                details.IsDoubleTapEnabled = false;
                details.IsHoldingEnabled = false;
                details.IsRightTapEnabled = false;
                details.Text = a.details;
                details.TextAlignment = TextAlignment.Left;
                details.VerticalAlignment = VerticalAlignment.Top;
                details.TextWrapping = TextWrapping.Wrap;
                
                

                ListViewItem date = new ListViewItem();
                date.Content = a.date;

                TextBlock title = new TextBlock();
                title.Text = a.title;
                title.FontSize = 25;
                title.TextAlignment = TextAlignment.Left;
                title.VerticalAlignment = VerticalAlignment.Top;
                title.TextWrapping = TextWrapping.Wrap;
                

                lw.Items.Add(title);
                lw.Items.Add(date);
                lw.Items.Add(image);
                lw.Items.Add(details);


                pi.Header = a.title;
                pivot.Items.Add(pi);
            }

            //Article a = new Article();
            /*
            a.title = "TITLE";
            a.details = "gdfgdfgdfkgjdfklgjdfklgjdflkj\nasdasdsdasdasdgdfg\nggfgdfgdgwerwer";
            a.date = "12.12.12 12:12:12";
            a.image = "http:\\www.sss.com";
            */
            //for (int i = 0; i <= 2; i++)
            //{
            
            //}
            


            

            // TODO: Если приложение содержит несколько страниц, обеспечьте
            // обработку нажатия аппаратной кнопки "Назад", выполнив регистрацию на
            // событие Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Если вы используете NavigationHelper, предоставляемый некоторыми шаблонами,
            // данное событие обрабатывается для вас.
        }

       
    }
}
