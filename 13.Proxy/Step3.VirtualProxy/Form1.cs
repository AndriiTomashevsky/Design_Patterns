using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Пользователь нажимает на кнопку. Во время загрузки заместитель выводит сообщение "Image Downloading....".
//Когда изображение будет полностью загружено, заместитель выводит графическое изображение

//Заместитель используется для замещения объекта, создание которого занимает относительно много времени(так как данные 
//передаются по сети). 

namespace Step3.VirtualProxy
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonTestImageProxy_Click(object sender, EventArgs e)
        {
            ImageProxy imageProxy = new ImageProxy(this);
            imageProxy.Request();                           //Заместитель создает RealSubject тогда, когда это необходимо. 
        }
    }
}
