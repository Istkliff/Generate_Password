using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
		string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"; //letters for selection
		string numbers = "0123456789"; //numbers for selection
		string symbols = "/*-+.=#@!%$^&()?|\"'/"; //symbols for selection
		string randomString = ""; //final string with all chars for generation

		public MainWindow()
		{
			InitializeComponent();
		}

		private void GenPass(object sender, RoutedEventArgs e) //Random generator method
		{
			string result = ""; //Reset the password string

			compareString();

			int size = getSize(); //getting size

			for (int i = size; i > 0; i--)
			{
				result += randomString[rnd.Next(randomString.Length)]; //Generation password with random size
			}

			FinalPass.Text = result; //Broadcast to textbox
		}

		private void CopyPass(object sender, RoutedEventArgs e)
		{
			if(String.IsNullOrEmpty(FinalPass.Text) == false) //Check if string is empty
			{
				Clipboard.SetText(FinalPass.Text);	//Copy to clipboard...
			} else
			{
				FinalPass.Text = "String is empty"; //...or display warning
			}
		}

		private void compareString() //making string for randomization password
		{
			randomString = "";

			if (CBLetters.IsChecked == true) 
			{
				randomString += letters; //add letters to password
			}

			if (CBNumbers.IsChecked == true)
			{
				randomString += numbers; //add numbers to password
			}

			if (CBSymbols.IsChecked == true)
			{
				randomString += symbols; //add symbols to password
			}
		}

		private void TBSize_previewtextinput(object sender, TextCompositionEventArgs e) //check on numbers in input
		{
			e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
		}

		private int getSize()
		{
			int size = Convert.ToInt32(TBSize.Text); //convert to int

			if(size > 0) //check on pozistive num
			{
				return size;
			} else
			{
				TBSize.Text = "1"; //set default num if num is negative
				return 1;
			}
		}
	}
}
