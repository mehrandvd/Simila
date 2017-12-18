<Query Kind="Statements" />

var filename = @"C:\Users\9215988\Documents\Visual Studio 2017\Projects\Simila.Mahan\Simila.Studio\bin\Debug\DirtySources\Tafsili-LegalEntity.txt";
var lines = File.ReadLines(filename);

var words = (
	from line in lines
	let parts = line.Split(' ').Where(p=>!string.IsNullOrWhiteSpace(p))
	where !string.IsNullOrWhiteSpace(line)
	select parts
	).SelectMany(p=>p);
	
	
var groups = 
	from word in words
	group word by word into wordgroup
	orderby wordgroup.Count() descending
	select new {Word = wordgroup.Key, Count = wordgroup.Count()}
	;

groups.Dump();