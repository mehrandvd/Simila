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

```c#
var simila = new Simila();

// Comparing Words
Assert.IsTrue(simila.AreSimilar("Lamborghini", "Lanborgini"));


// Comparing Expressions
Assert.IsTrue(simila.AreSimilar("Lamborghini is some great car", "Lanborgini is some graet kar"));
```
## Setting Similarity **Treshold**
You can check similarities with desired `Treshold`:
This an easy going similarity checker:
```c#
// Accepts as similar if their at least 50% similar.
var similaEasy = new Simila() { Treshold=0.5 };
// considered as similar.
Assert.IsTrue(similaEasy.IsSimilar("Lamborghini", "Lanborgni"));
```
and this is a tough one:
``` c#
// Accepts as similar if their at least 80% similar.
var similaHard = new Simila() { Treshold=0.8 };
// considered as NOT similar!
Assert.IsFalse(similaEasy.AreSimilar("Lamborghini", "Lanborgni"));
```

## Simila knows typical mistakes
You know that `Car` is more similar to `Kar` than to `Nar`, because `C` and `K` are more mistakable than `C` and `N`.
Also `Color` is more similar to `Colour` than "Kolor".
Simila **is aware of common mistakes**.

Also, Simila lets you to train her. 




We studied lots of similarity scenarios in business applications and tried to design Simila as a good answer for these business scenarios.
