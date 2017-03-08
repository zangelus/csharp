using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncAwait
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                LoginButton.IsEnabled = false;
                
                //as a rule, we should always await an Async operation or if we are calling a method that returns a Task, it is best practive to use the await keyword tp await for that.
                var result = await LoginAsync(); //Everything after the await keyword is executed as a continuation once the asyn results are returned.
                //var result = await LoginAsync1(); //Everything after the await keyword is executed as a continuation once the asyn results are returned.

                LoginButton.Content = result;

                LoginButton.IsEnabled = true;
                
            }
            catch (Exception )
            {
                LoginButton.Content = "Internal Error";
            }
        }

        private async Task<string> LoginAsync()
        {
            try
            {
                //In order to fire all of the tasks at the same time, remove the await.
                //The following 3 asynchronous operations are going to be fire off at the same time.
                var loginTask = Task.Run(()=> //after each await is done, we are back in the calling thread
                {
                    Thread.Sleep(2000);
                    return "Login successfull";
                });
                var logTask = Task.Delay(2000);
                var fetchTask = Task.Delay(1000);

                //Now I dont want to return from this method until all of these tasks are done!
                await Task.WhenAll(loginTask, logTask, fetchTask); //it returns a Task itself so I can set up a continuation when all of these task are completed.


                return loginTask.Result; //doing a .Result of a Task is blocking "when the result is not available" but since from the previous line it returs to the UI thread once all task are done, it means this return will execute immediatly
            }
            catch (Exception )
            {
                return "Login failed";
            }
                
        }

        private async Task<string> LoginAsync1()
        {
            try
            {
                //throw new UnauthorizedAccessException(); Test 1
                var result = await Task.Run(() => //after each await is done, we are back in the calling thread
                {
                    //throw new UnauthorizedAccessException(); Test 2 
                    Thread.Sleep(2000);
                    return "Login successfull";
                });

                //it means we are in the UI thread in this line

                await Task.Delay(2000); //To simulate delays as with thread sleep
                                        //after each await is done, we are back in the calling thread

                //it means we are back in the UI thread in this line

                await Task.Delay(1000); //another delay as fetch the data from the DB

                //it means we are back in the UI thread in this line

                return result;
            }
            catch (Exception)
            {
                return "Login failed";
            }

        }


    }
}
