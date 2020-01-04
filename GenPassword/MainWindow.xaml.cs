using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GenPassword
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Random rnd = new Random(); //Random method
		string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz/*-+.=#@!%$^&()?|\"'/"; //Main symbols for random generation
		public MainWindow()
		{
			InitializeComponent();
		}

		private void GenPass(object sender, RoutedEventArgs e) //Random generator method
		{
			string result = ""; //Reset the password string

			for (int i = rnd.Next(5,50); i > 0; i--)
			{
				result += chars[rnd.Next(chars.Length)]; //Generation password with random size
			}

			FinalPass.Text = result; //Broadcast to textbox
		}
	}
}
