using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Step3.VirtualProxy
{
    class ImageProxy
    {
        private static Image image = null;  // RealSubject (большой "затратный" объект). Класс для вывода графического изображения
        private int width = 133;
        private int height = 154;
        private bool retrieving = false;
        Form1 form1;

        public ImageProxy(Form1 form1)
        {
            this.form1 = form1;
        }

        public int Width
        {
            get { return image == null ? width : image.Width; }
        }
        public int Height
        {
            get { return image == null ? height : image.Height; }
        }

        //Заместитель может обработать запрос или — если объект RealSubject уже был созан, — делегировать вызовы RealSubject
        //Метод вызывается тогда, когда требуется вывести изображение на экране.
        public void Request()
        {
            // Если объект уже был загружен, то выводим его
            if (image != null)
            {
                form1.pictureBox.Image = image;
            }
            //В противном случае выводится сообщение о загрузке
            else
            {
                //Виртуальный Заместитель выполняет функции суррогатного представителя RealSubject до и во время создания 
                //RealSubject. 
                // In the meantime(while retrieving) ImageProxy provides a placeholder image that is stored locally.
                form1.pictureBox.Image = PlaceHolderImage(); // Выводится сообщение о загрузке

                // Если загрузка изображения еще не началась
                if (!retrieving)
                {
                    //...можно начать загрузку
                    retrieving = true;
                    // Чтобы загрузка не парализовала пользовательский интерфейс, она будет выполнятся в отдельном потоке
                    Thread retrievalThread = new Thread(GetImage);
                    retrievalThread.Start();
                }
            }
        }

        // Второй вариант
        //public Image PlaceHolderImage()
        //{
        //    Assembly currentlyExecutingAssembly = Assembly.GetExecutingAssembly();
        //    Stream loadImageStream = currentlyExecutingAssembly.GetManifestResourceStream("Step3.VirtualProxy.PlaceHolder.jpg");
        //    Bitmap bitmap = new Bitmap(loadImageStream);
        //    return bitmap;
        //}

        public Image PlaceHolderImage()      // Первый вариант
        {
            Rectangle rectangle = new Rectangle(10, 10, 154, 133);
            Pen pen = new Pen(Color.Black);
            Bitmap bitmap = new Bitmap(800, 600);
            Graphics g = Graphics.FromImage(bitmap);
            Font font = new Font("Arial", 12);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawRectangle(pen, rectangle);
            g.DrawString("Image Downloading....", font, brush, 10, 60);

            return bitmap;
        }

        // Здесь загружается НАСТОЯЩЕЕ изображение.
        public void GetImage()
        {
            // Retrieves a book cover image from amazon.com on a separate thread.
            // URI - Uniform Resource Identifier (Уникальный идентификатор ресурса)
            string requestUriStringr = "http://images.amazon.com/images/P/0596007124.01._PE34_SCMZZZZZZZ_.jpg";

            // Загрузка данных с сетевого URL-адреса.
            HttpWebRequest webRequestInstance = (HttpWebRequest)WebRequest.Create(requestUriStringr);

            //Во время передачи графических данных ImageProxy выводит сообщение «Image Downloading....». 
            HttpWebResponse response = (HttpWebResponse)webRequestInstance.GetResponse();
            Stream containingBodyResponseStream = response.GetResponseStream();
            image = Image.FromStream(containingBodyResponseStream);

            // После завершения загрузки оповещаем Form1 о необходимости перерисовки
            form1.pictureBox.Image = image;

            //Таким, образом, при следующем перерисовке экрана после создания экземпляра Image метод Request 
            //выведет изображение, не текстовое сообщение.
        }
    }
}
