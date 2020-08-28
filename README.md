# Introducing Simila
Are **Color** and **Colour** equal? No!

```c#
if ("Color" == "Coluor")
   // Always false

if ("The Candy Shop" == "The Kandi Schap")
   // Always false
```

But they **are Similar** in **Simila**!

```c#
if (simila.AreSimilar("Color", "Colour"))
   // It's true now!

if (simila.AreSimilar("The Candy Shop", "The Kandi Schap"));
   // It's true now!
```

# How to use
Using Simila is easy.

First of all, install [Bit.Simila](https://www.nuget.org/packages/Bit.Simila/) nuget package.

```c#
var simila = new Simila();

// Comparing Words
simila.AreSimilar("Lamborghini", "Lanborgini"); // True


// Comparing Expressions
simila.AreSimilar("Lamborghini is some great car", "Lanborgini is some graet kar"); // True
```
## Customizing Simila 

### **Treshold**
You set the sensivity of similarity by setting `Treshold`:

```c#
// Are similar if their at least 50% similar.
var similaEasy = new Simila()
{
    Treshold=0.5 
};

// considered as similar.
similaEasy.IsSimilar("Lamborghini", "Lanborgni"); // True, They are 50% similar.

// Are similar if their at least 80% similar.
var similaTough = new Simila() 
{ 
    Treshold=0.8 
};

// considered as NOT similar!
similaEasy.AreSimilar("Lamborghini", "Lanborgni"); // False, Not 80% similar.
```

### Similarity Resolver
There are 3 types of similarity resolvers available in Simila:
    - Levenshein (Default)
    - Soundex
    - SharedPair
    
 Each algorithm works fine it is being used in its proper scenario.
 
 You can configure simila to use these just like:
 
 ```c#
var similaSounedx = new Simila()
{
    resolver = new SoundexSimilarityResolver()
    Treshold = 0.5 
};

var similaSharedPair = new Simila()
{
    resolver = new SharedPairSimilarityResolver()
    Treshold = 0.5 
};
```

Levenshtein is even more configurable. You can set the accepted mistakes both character level and word level.
In this example we told Simila to consider `c` and `k` similar and also, `color` and `colour` similar.
```c#
 var simila = new Simila(
    threshold: 1,
    resolver: new PhraseSimilarityResolver(
                  new WordSimilarityResolver(
                     new MistakeRepository<Word>(new Mistake<Word>[]
                     {
                         ("color", "colour", 1)
                     }),
                     new CharacterSimilarityResolver(
                        new MistakeRepository<char>(new Mistake<char>[]
                        {
                           ('c', 'k', 1)
                        })
                     )
                 )
    )
);
```

## Simila knows typical mistakes
You know that `Car` is more similar to `Kar` than to `Nar`, because `C` and `K` are more mistakable than `C` and `N`.
Also `Color` is more similar to `Colour` than "Kolor".
Simila **is aware of common mistakes**.

Also, Simila lets you to train her. 




We studied lots of similarity scenarios in business applications and tried to design Simila as a good answer for these business scenarios.
