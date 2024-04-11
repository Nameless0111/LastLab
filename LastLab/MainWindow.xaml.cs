using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LastLab;
using LastLab.DataSet1TableAdapters;

namespace LastLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        TraderTableAdapter adapter = new TraderTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Window5 window5 = new Window5();
            window5.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int ac = 0;
                var passw = adapter.GetData().Rows;
                for (int i = 0; passw.Count > i; i++)
                {
                    if (passw[i][1].ToString() == NameTbx.Text && passw[i][5].ToString() == PasswordTbx.Password)
                    {
                        int access = (int)passw[i][4];

                        switch (access)
                        {

                            case 1:
                                Window1 window = new Window1();
                                window.Show();
                                ac = 1;
                                break;
                            case 2:
                                Window2 window2 = new Window2();
                                window2.Show(); ac = 1; break;
                            case 3:
                                Window3 window3 = new Window3();
                                window3.Show(); ac = 1; break;
                            case 4:
                                Window4 window4 = new Window4();
                                window4.Show(); ac = 1; break;


                        }
                        break;
                    }


                }
                if (ac != 1)
                {
                    MessageBox.Show("Имя или пароль введены неверно!");
                }
            }
            catch { MessageBox.Show("Что-то введено не так!"); }
        }
    }
    public partial class Window1 : Window
    {
        METROEntities entity = new METROEntities();
        //List<krasivo> krasivos = new List<krasivo>();
        public Window1()
        {
            InitializeComponent();
            /*foreach (var item in entity.Product.ToList().Where(item => item.Category_ID == 1))
            {
                krasivos.Add(new krasivo(item));
            }
            Prosuct.ItemsSource = krasivos;*/
            Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
            

        }
        private bool Check(string text, int num)
        {
            if (text.Length > 0 && text.Length <= num) { return true; }
            return false;
        }
        private void Prosuct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Prosuct.SelectedItem != null)
            {
                var data = Prosuct.SelectedItem as Product;
                NameTbx.Text = data.Name.ToString();
                ParticularPriceTbx.Text = Convert.ToString(data.ParticularPrice);
            }
        }

     
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Name.Contains(SearchTbx.Text));

        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            /* foreach (var item in entity.Product.ToList().Where(item => item.Category_ID == 1))
             {
                 krasivos.Add(new krasivo(item));
             }
             Prosuct.ItemsSource = krasivos;*/
            Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var gen = new Product();
                gen.Name = NameTbx.Text;
                int price;
                Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price);
                MessageBox.Show(price.ToString());
                gen.ParticularPrice = price;
                gen.Category_ID = 1;
                entity.Product.Add(gen);
                entity.SaveChanges();
                Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    entity.Product.Remove(gen);
                    entity.SaveChanges();
                    Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);

                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    gen.Name = NameTbx.Text;
                    gen.Category_ID = 1;
                    int price;
                    if (Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price) && price > 0)
                    {

                        gen.ParticularPrice = price;
                        entity.SaveChanges();
                        Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
                    }
                    else { MessageBox.Show("Введено некорректное значение!"); }
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }


    }
    public partial class Window2 : Window
    {
        METROEntities entity = new METROEntities();
        public Window2()
        {
            //List<krasivo> krasivos = new List<krasivo>();

            InitializeComponent();
            /*foreach (var item in entity.Product.ToList().Where(item => item.Category_ID == 1))
            {
                krasivos.Add(new krasivo(item));
            }
            Prosuct.ItemsSource = krasivos;*/
            Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 2);

        }
        private bool Check(string text, int num)
        {
            if (text.Length > 0 && text.Length <= num) { return true; }
            return false;
        }
        private void Prosuct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Prosuct.SelectedItem != null)
            {
                var data = Prosuct.SelectedItem as Product;
                NameTbx.Text = data.Name.ToString();
                ParticularPriceTbx.Text = Convert.ToString(data.ParticularPrice);
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var gen = new Product();
                gen.Name = NameTbx.Text;
                int price;
                Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price);
                MessageBox.Show(price.ToString());
                gen.ParticularPrice = price;
                gen.Category_ID = 1;
                entity.Product.Add(gen);
                entity.SaveChanges();
                Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    entity.Product.Remove(gen);
                    entity.SaveChanges();
                    Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);

                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    gen.Name = NameTbx.Text;
                    gen.Category_ID = 1;
                    int price;
                    if (Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price) && price > 0)
                    {

                        gen.ParticularPrice = price;
                        entity.SaveChanges();
                        Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
                    }
                    else { MessageBox.Show("Введено некорректное значение!"); }
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
    }
    public partial class Window3 : Window
    {
        METROEntities entity = new METROEntities();
        public Window3()
        {
            //List<krasivo> krasivos = new List<krasivo>();

            InitializeComponent();
            /*foreach (var item in entity.Product.ToList().Where(item => item.Category_ID == 1))
            {
                krasivos.Add(new krasivo(item));
            }
            Prosuct.ItemsSource = krasivos;*/
            Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 3);

        }
        private bool Check(string text, int num)
        {
            if (text.Length > 0 && text.Length <= num) { return true; }
            return false;
        }
        private void Prosuct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Prosuct.SelectedItem != null)
            {
                var data = Prosuct.SelectedItem as Product;
                NameTbx.Text = data.Name.ToString();
                ParticularPriceTbx.Text = Convert.ToString(data.ParticularPrice);
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var gen = new Product();
                gen.Name = NameTbx.Text;
                int price;
                Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price);
                MessageBox.Show(price.ToString());
                gen.ParticularPrice = price;
                gen.Category_ID = 1;
                entity.Product.Add(gen);
                entity.SaveChanges();
                Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    entity.Product.Remove(gen);
                    entity.SaveChanges();
                    Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);

                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    gen.Name = NameTbx.Text;
                    gen.Category_ID = 1;
                    int price;
                    if (Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price) && price > 0)
                    {

                        gen.ParticularPrice = price;
                        entity.SaveChanges();
                        Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
                    }
                    else { MessageBox.Show("Введено некорректное значение!"); }
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
    }
    public partial class Window4 : Window
    {
        METROEntities entity = new METROEntities();
        public Window4()
        {
            //List<krasivo> krasivos = new List<krasivo>();

            InitializeComponent();
            /*foreach (var item in entity.Product.ToList().Where(item => item.Category_ID == 1))
            {
                krasivos.Add(new krasivo(item));
            }
            Prosuct.ItemsSource = krasivos;*/
            Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 4);

        }
        private bool Check(string text, int num)
        {
            if (text.Length > 0 && text.Length <= num) { return true; }
            return false;
        }
        private void Prosuct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Prosuct.SelectedItem != null)
            {
                var data = Prosuct.SelectedItem as Product;
                NameTbx.Text = data.Name.ToString();
                ParticularPriceTbx.Text = Convert.ToString(data.ParticularPrice);
            }
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var gen = new Product();
                gen.Name = NameTbx.Text;
                int price;
                Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price);
                MessageBox.Show(price.ToString());
                gen.ParticularPrice = price;
                gen.Category_ID = 1;
                entity.Product.Add(gen);
                entity.SaveChanges();
                Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    entity.Product.Remove(gen);
                    entity.SaveChanges();
                    Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);

                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Prosuct.SelectedItem != null && Check(NameTbx.Text, 30))
                {

                    var gen = Prosuct.SelectedItem as Product;
                    gen.Name = NameTbx.Text;
                    gen.Category_ID = 1;
                    int price;
                    if (Int32.TryParse(ParticularPriceTbx.Text.ToString(), out price) && price > 0)
                    {

                        gen.ParticularPrice = price;
                        entity.SaveChanges();
                        Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == 1);
                    }
                    else { MessageBox.Show("Введено некорректное значение!"); }
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Product.ToList();
        }
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Purchase.ToList();
        }
        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Sitizenship.ToList();
        }
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.AccessRank.ToList();
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Category.ToList();
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Cost.ToList();
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Customer.ToList();
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Trader.ToList();
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.Cheque.ToList();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Prosuct.ItemsSource = entity.TypeOfInterraction.ToList();
        }
    }
    public partial class Window5 : Window
    {
        METROEntities entity = new METROEntities();
        public Window5()
        {
            //List<krasivo> krasivos = new List<krasivo>();

            InitializeComponent();
            /*foreach (var item in entity.Product.ToList().Where(item => item.Category_ID == 1))
            {
                krasivos.Add(new krasivo(item));
            }
            Prosuct.ItemsSource = krasivos;*/
            Prosuct.ItemsSource = entity.Product.ToList();
            FilterTbx.ItemsSource = entity.Category.ToList();
         
        }
        private void FilterTbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (FilterTbx.SelectedItem != null)
            {
                var selected = FilterTbx.SelectedItem as Category;

                Prosuct.ItemsSource = entity.Product.ToList().Where(item => item.Category_ID == selected.ID_Category);

            }
        
        }

    }
}

    
    /*internal class krasivo
    {
        
        public int ID_Product;
        
        public string Name { get; private set; }
        public int ParticularPrice { get; private set; }


        public krasivo(Product red)
        {
            ID_Product = red.ID_Product;
            Name = red.Name;
        ParticularPrice = red.ParticularPrice;
        }
   /* internal class krasivo
    {

        public int ID_Reader;

        public string Surname { get; private set; }
        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string Library_Card_Number { get; private set; }

        public int Genre_ID;
        public string genre { get; private set; }
        public krasivo(Readers red)
        {
            ID_Reader = red.ID_Reader;
            Surname = red.Surname;
            FirstName = red.FirstName;
            MiddleName = red.MiddleName;
            Library_Card_Number = red.Library_Card_Number;
            if (red.Genres != null)
            {
                Genre_ID = red.Genre_ID;
                genre = red.Genres.genre;
            }
        }*/
    

