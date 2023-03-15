using System.Data;

namespace CalculatorMobProgrammingTemplate;

public partial class MainPage : ContentPage
{
    private bool _cannotCompute;

    public MainPage()
	{
		InitializeComponent();
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (_cannotCompute)
            {
                InputOutput.Text = btn.Text;
                _cannotCompute = false;
            }
            else
            {
                InputOutput.Text += btn.Text;
            }
        }
    }

    private void ClearButton_OnClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            if (_cannotCompute)
            {
                _cannotCompute = false;
            }
            InputOutput.Text = string.Empty;
        }
    }

    private void BackspaceButton_OnClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            InputOutput.Text = InputOutput.Text[..^1];
        }
    }

    private void CalculateButton_OnClicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            var maths = InputOutput.Text;
            try
            {
                var results = Convert.ToString(new DataTable().Compute(maths, null));
                InputOutput.Text = results;

            }
            catch (Exception exception)
            {
                InputOutput.Text =  "Kan inte räkna ut...";
                _cannotCompute = true;
            }
        }
    }
}

