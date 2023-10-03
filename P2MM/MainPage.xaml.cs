using Microsoft.Maui.Controls;

namespace P2MM;

public partial class MainPage : ContentPage
{
    //Main array divided in ROWS and COLS- game grid 1
    BoxView[,] bv = new BoxView[10, 4];
    //Same array divided by num ID- game grid 1
    BoxView[] bv2 = new BoxView[40];
    //Random box view array
    BoxView[] rBV = new BoxView[4];
    //Game grid 2 array
    BoxView[,] bv3 = new BoxView[10, 4];
    //Random array
    int[] rand = new int[4];

    int num = 0;

    Random _random;

    public MainPage()
	{
		InitializeComponent();
        _random = new Random();
        StartTheGame();
    }
    //Start of the game
    private void StartTheGame() 
    {
        //Visability of elemets
        StartBtn.IsVisible = true;
        BtnStack.IsVisible = false;
        GameGrid.IsVisible = false;
        GameGrid2.IsVisible = false;
        ResetBtn.IsVisible = false;

        SetUpGameGrid();
        SetUpRandom();
    }
    //Sets up 2 grids
    private void SetUpGameGrid()
	{
        //Counts ID of each element
        int z = 0; 

		for (int i = 0; i < 10; i++)
		{
            //Display box views in game grid 1
            for (int j = 0; j < 4; j++)
			{
				bv[i, j] = new BoxView();
				bv[i, j].Color = Colors.Beige;     
                bv[i, j].WidthRequest = 20;
                bv[i, j].HeightRequest = 20;
                bv[i, j].CornerRadius = 50;
                bv[i, j].SetValue(Grid.RowProperty, i);
				bv[i, j].SetValue(Grid.ColumnProperty, j);
                GameGrid.Children.Add(bv[i, j]);
				bv2[z] = bv[i, j];
				z++;
            }
            //Display box views in game grid 2
            for (int j = 0; j < 4; j++)
            {
                bv3[i, j] = new BoxView();
                bv3[i, j].Color = Colors.Black;
                bv3[i, j].WidthRequest = 10;
                bv3[i, j].HeightRequest = 10;
                bv3[i, j].CornerRadius = 50;
                bv3[i, j].SetValue(Grid.RowProperty, i);
                bv3[i, j].SetValue(Grid.ColumnProperty, j);
                GameGrid2.Children.Add(bv3[i, j]);
            }
        }
	}
    //Generates random numbers and assings colours to box views
    private void SetUpRandom()
    {
        for (int i = 0; i < 4; i++)
        {
            rand[i] = _random.Next(1, 7);
        }
        for (int i = 0; i < 4; i++)
        {
            //Creating box view objects for random numbers
            rBV[i] = new BoxView();
            rBV[i].WidthRequest = 30;
            rBV[i].HeightRequest = 30;
            rBV[i].CornerRadius = 50;
            rBV[i].Margin = 10;
            rBV[i].SetValue(Grid.RowProperty, 11);
            rBV[i].SetValue(Grid.ColumnProperty, i);
            rBV[i].IsVisible = false;
            GameGrid.Children.Add(rBV[i]);

            //Giving random numbers colours
            if (rand[i] == 1)
            {
                rBV[i].Color = Colors.Red;
            }
            if (rand[i] == 2)
            {
                rBV[i].Color = Colors.Yellow;
            }
            if (rand[i] == 3)
            {
                rBV[i].Color = Colors.Green;
            }
            if (rand[i] == 4)
            {
                rBV[i].Color = Colors.Blue;
            }
            if (rand[i] == 5)
            {
                rBV[i].Color = Colors.Purple;
            }
            if (rand[i] == 6)
            {
                rBV[i].Color = Colors.Orange;
            }
        }
    }
    //Checks if selected colour is same as random colour
    private void CheckTheColours()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 4; j++)
            { 
                //If correct colour on correct place
                if (bv[i, j].Color.Equals(rBV[j].Color))
                {
                    bv3[i, j].Color = Colors.Red;
                }
                //If correct colour but NOT correct place
                for (int z = 0; z < 4; z++)
                {
                    if (bv[i, j].Color.Equals(rBV[z].Color) && !bv[i, j].Color.Equals(rBV[j].Color))
                    {                 
                        bv3[i, j].Color = Colors.White;                 
                    }
                }
            }
        }
    }
    //End of the game
    private async void EndTheGame()
    {
        bool win = false;
        //If user wins
        //If random array is exactly same as the selected one
        for (int i = 0; i < 10; i ++)
        {
            if (bv[i, 0].Color == rBV[0].Color && bv[i, 1].Color == rBV[1].Color && bv[i, 2].Color == rBV[2].Color && bv[i, 3].Color == rBV[3].Color)
            {
                for (int j = 0; j < 4; j++)
                {
                    rBV[j].IsVisible = true;
                    win = true;
                }
            }
        }
        //If user lose
        //If user stays without guesses
        if (num == 40)
        {
            for (int j = 0; j < 4; j++)
            {
                rBV[j].IsVisible = true;
                win = false;
            }
        }
        if (win == true)
        {
            await DisplayAlert("Alert", "Game Over\nYOU WON!", "OK");
        }
        if (num == 40 && win != true)
        {
            await DisplayAlert("Alert", "Game Over\nYOU LOST!", "OK");
        }
        
    }
    private void BtnRed_Clicked(object sender, EventArgs e)
    {
		bv2[num].Color = Colors.Red;
		num++;
        CheckTheColours();
        EndTheGame();
    }
    private void BtnYellow_Clicked(object sender, EventArgs e)
    {
        bv2[num].Color = Colors.Yellow;
        num++;
        CheckTheColours();
        EndTheGame();
    }
    private void BtnGreen_Clicked(object sender, EventArgs e)
    {
        bv2[num].Color = Colors.Green;
        num++;
        CheckTheColours();
        EndTheGame();
    }

    private void BtnBlue_Clicked(object sender, EventArgs e)
    {
        bv2[num].Color = Colors.Blue;
        num++;
        CheckTheColours();
        EndTheGame();
    }

    private void BtnPurple_Clicked(object sender, EventArgs e)
    {
        bv2[num].Color = Colors.Purple;
        num++;
        CheckTheColours();
        EndTheGame();
    }
    private void BtnOrange_Clicked(object sender, EventArgs e)
    {
        bv2[num].Color = Colors.Orange;
        num++;
        CheckTheColours();
        EndTheGame();
    }
    private void ResetBtn_Clicked(object sender, EventArgs e)
    {
        num = 0;

        for (int i = 0; i < 4; i++)
        {
            rBV[i].IsVisible = false;
        }
        //Reset the game
        SetUpGameGrid();
        SetUpRandom();
        StartTheGame();
    }
    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        //Visability of the elements
        StartBtn.IsVisible =false;
        BtnStack.IsVisible = true;
        GameGrid.IsVisible = true;
        GameGrid2.IsVisible = true;
        ResetBtn.IsVisible = true;
    }
}

