using NUnit.Framework;

namespace Simila.Core.Tests {
    [TestFixture]
    public class LevenshteinBasicTests {

        //[Test(Description = "Testig the basic computations")]
        public void BasicComputations()
        {
        //    var levenshteinAlgorithmWord = new DefaultWordLevensteinAlgorithm();
        //    var costResolverWord = levenshteinAlgorithmWord.similarityResolver;

        //    var levenshteinAlgorithmPhrase = new PhraseLevensteinAlgorithm();
        //    var costResolverPhrase = levenshteinAlgorithmPhrase.similarityResolver;

        //    var levPhraseCaseSensitive = new PhraseLevensteinAlgorithm();
        //    var costResolverPhraseCaseSensitive = levPhraseCaseSensitive.similarityResolver;

        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("AAA"), new Word("BBBBB")), 5);

        
        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Cat"), new Word("Kat")), 1);
        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Afshin"), new Word("Afsoon")), 2);
        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Monitor"), new Word("Monitoring")), 3);
        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Main"), new Word("Monitor")), 5);

        //    //phrase test ,Distance
        //    Assert.AreEqual((decimal)levenshteinAlgorithmPhrase.GetDistance(new Phrase("خوبم مرسی"), new Phrase("سلام چطوری")), 1.55);
        //    Assert.AreEqual((decimal)levenshteinAlgorithmPhrase.GetDistance(new Phrase("قسمت فروش شرکت ماندگار"), new Phrase("واحد فروش شرکت ماندگار")),1);
        //    Assert.AreEqual((decimal)levenshteinAlgorithmPhrase.GetDistance(new Phrase("شرکت برنامه ریزی شیوه"), new Phrase("شرکت برنامه ریزی ماندگار")), 0.8);
        //    Assert.AreEqual((decimal)levenshteinAlgorithmPhrase.GetDistance(new Phrase("شرکت ماندگار"), new Phrase("شرکت ماندگار2")), 0.166666666666667);

        //    //phrase test ,Similarity
        //    Assert.AreEqual(
        //        (decimal) levenshteinAlgorithmPhrase.GetSimilarity(new Phrase("شرکت ماندگار"), new Phrase("شرکت ماندگار2")),0.916666666666667);
        //    //case sensititve test 
        //    Assert.AreEqual((decimal)levenshteinAlgorithmPhrase.GetDistance(new Phrase("AAaaAAbBB"), new Phrase("aaaaaabbb")), 0);
        //    Assert.AreEqual((decimal)levPhraseCaseSensitive.GetDistance(new Phrase("AAaaAAbBB"), new Phrase("aaaaaabbb")), 0.666666666666667);

        //    costResolverWord.SetMistakeSimilarity('C', 'K', 0.5);
        //    costResolverWord.SetMistakeSimilarity('c', 'k', 0.5);
        //    costResolverWord.SetMistakeSimilarity('N', 'M', 0.5);

        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Cat"), new Word("Kat")), 0.5);

        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Monica"), new Word("Nonica")), 0.5);
        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Monica"), new Word("Noxica")), 1.5);
        //    Assert.AreEqual(levenshteinAlgorithmWord.GetDistance(new Word("Monica"), new Word("Noxika")), 2);


        //}


        //[Test(Description = "Testing the similarity function")]
        //public void BasicSimilarities()
        //{
        //    //var LevensteinAlgorithm = new LevensteinAlgorithm();
        //    //LevensteinAlgorithm.GetDistance("asdfasf", "asdfasf");
            
        //    //var costResolver = new DefaultCharacterSimilarityResolver();
        //    //costResolver.SetMistakeSimilarity('C', 'K', 0.5);
        //    //costResolver.SetMistakeSimilarity('c', 'k', 0.5);
        //    //costResolver.SetMistakeSimilarity('N', 'M', 0.5);


        //    //Assert.GreaterOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("AAAAA", "AAABB"), .5,
        //    //    "AAAAA is similar to AAABB");

        //    //Assert.GreaterOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("Cat", "Kat"), .5,
        //    //    "Cat is similar to Kat");

        //    //Assert.GreaterOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("Mehran", "Nehran"), .5,
        //    //    "Mehran is similar to Nehran");

        //    //Assert.GreaterOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("Ali", "Aly"), .5,
        //    //    "Ali is similar to Aly");
            
        //    //Assert.GreaterOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("Monica", "Noxica"), .5,
        //    //    "Monica is similar to Noxica");
            
        //    //Assert.GreaterOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("Monica", "Noxika"), .5, 
        //    //    "Monica is similar to Noxika");



        //    //Assert.LessOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("AAAAA", "BBBBB"), .5,
        //    //    "AAAAA is not similar BBBBB");

        //    //Assert.LessOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("AAAAA", "ABBBB"), .5,
        //    //    "AAAAA is not similar ABBBB");
            
            
        //    //Assert.LessOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("AAAAA", "AABBB"), .5, 
        //    //    "AAAAA is not similar AABBB");
            
        //    //Assert.LessOrEqual(
        //    //    LevensteinAlgorithm.GetSimilarity("AABBB", "AAAAA"), .5, 
        //    //    "AAAAA is not similar AABBB");


        //    //costResolver.AddEnglishCommonMistakes();
        //    //costResolver.AddPersianCommonMistakes();



        //    //Assert.LessOrEqual(ld.GetSimilarity("Ahmad", "Bamdad"), .5);
        //    //Assert.LessOrEqual(ld.GetSimilarity("Nicolas", "Mikomoc"), .5);




        }
    }
}
