// Level 4 chapter
Console.WriteLine("Why don't you enter the heigth of the Triangle");

uint _height = 0;
if (uint.TryParse(Console.ReadLine(), out uint heightResult))
    _height = heightResult;

Console.WriteLine("Why dont you now enter the base of the triangle");

uint _base = 0;
if (uint.TryParse(Console.ReadLine(), out uint baseResult))
    _base = baseResult;

if (_height > 0 && _base > 0)
{
    Console.WriteLine(_height * _base / 2);
}
else
    Console.WriteLine("Cannot calculate the area of the triangle");