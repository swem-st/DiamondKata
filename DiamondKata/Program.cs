using DiamondKata.DomainModels;

var diamond = Diamond.CreateNew('k');
var diamondString = diamond.GetDiamondAsString();
Console.WriteLine(diamondString);