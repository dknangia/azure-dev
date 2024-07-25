Console.WriteLine("Input X co-ordinates");
int x = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Input Y co-oridinates");
int y = Convert.ToInt32(Console.ReadLine());

string direction = string.Empty;
string Message = $"Enemy is in {direction}";
if (y > 0)
{
    if (x < 0)
    {
        direction = "NW";
    }
    else if (x == 0)
    {
        direction = "N";
    }
    else if (x > 0)
    {
        direction = "NE";
    }
}
else if (y == 0)
{
    if (x < 0)
    {
        direction = "W";
    }
    else if (x == 0)
    {
        direction = "!";
    }
    else if (x > 0)
    {
        direction = "E";
    }
}
else if (y < 0)
{
    if (x < 0)
    {
        direction = "SW";
    }
    else if (x == 0)
        //{
        direction = "S";
}
else if (x > 0)
{
    direction = "SE";
}
}


Console.WriteLine(direction == "!" ? "Enemy is here" : Message);