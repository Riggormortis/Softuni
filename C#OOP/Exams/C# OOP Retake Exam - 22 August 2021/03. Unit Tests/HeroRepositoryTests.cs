using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{
    
    private const string HeroName = "Some name";
    private const int HeroLevel = 5;

    private HeroRepository heroRepository;
    private Hero hero;

    [SetUp]
    public void Setup()
    {
        this.heroRepository = new HeroRepository();
        this.hero = new Hero(HeroName, HeroLevel);
    }

    [Test]
    public void ConstructorCreatesAnEmptyCollection()
    {
        Assert.That(this.heroRepository.Heroes.Count, Is.Zero);
    }

    [Test]
    public void CreateThrowsExceptionWhenHeorIsNull()
    {
        Assert.That(() => this.heroRepository.Create(null), Throws.ArgumentNullException);
    }

    [Test]
    public void CreateThrowsException_WhenAlreadyThereIsAHeroWithTheSameName()
    {
        var hero = new Hero(HeroName, HeroLevel);
        this.heroRepository.Create(hero);

        var hero2 = new Hero(HeroName, HeroLevel + 2);

        Assert.That(() => this.heroRepository.Create(hero), Throws.InvalidOperationException);
    }


    [Test]
    public void CreateWorksProperly()
    {
        var hero = new Hero(HeroName, HeroLevel);
        

        string expectedResult = $"Successfully added hero {HeroName} with level {HeroLevel}";

        string actual = this.heroRepository.Create(hero);

        Assert.AreEqual(this.heroRepository.Heroes.Count, 1);

        Assert.That(expectedResult, Is.EqualTo(actual));
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void RemoveThrowsExceptionWhenHeorIsNullorEmpty(string name)
    {
        this.heroRepository.Create(this.hero);

        Assert.That(() => this.heroRepository.Remove(name), Throws.ArgumentNullException);
    }


    [Test]
    public void RemoveWorksProperlyTrue()
    {
        var hero = new Hero(HeroName, HeroLevel);
        this.heroRepository.Create(hero);
        Assert.AreEqual(this.heroRepository.Heroes.Count, 1);

        Assert.IsTrue(this.heroRepository.Remove(HeroName));
        Assert.That(this.heroRepository.Heroes.Count, Is.Zero);

    }

    [Test]
    public void RemoveWorksProperlyFalse()
    {
        var hero = new Hero(HeroName, HeroLevel);
        this.heroRepository.Create(hero);
        Assert.AreEqual(this.heroRepository.Heroes.Count, 1);

        bool result = this.heroRepository.Remove("Fake name");
        Assert.AreEqual(this.heroRepository.Heroes.Count, 1);

        Assert.That(result, Is.False);


    }

    [Test]
    public void GetHeroWithHighestLevelWorksProperly()
    {
        var hero = new Hero(HeroName, HeroLevel);
        var hero2 = new Hero("Pencho", 10);
        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero2);
        Assert.AreEqual(this.heroRepository.Heroes.Count, 2);

        var heroToGet= hero2;

        Assert.AreEqual(this.heroRepository.GetHeroWithHighestLevel(), heroToGet);

    }

    [Test]
    public void GetHeroWithHighestLevel_ThrowsException_WhenTheCollectionIsEmpty()
    {
        Assert.Throws<IndexOutOfRangeException>(() => this.heroRepository.GetHeroWithHighestLevel());
    }

    [Test]
    public void GetHeroWorksProperly()
    {
        var hero = new Hero(HeroName, HeroLevel);
        var hero2 = new Hero("Pencho", 10);
        this.heroRepository.Create(hero);
        this.heroRepository.Create(hero2);
        Assert.AreEqual(this.heroRepository.Heroes.Count, 2);

        var heroToGet = hero;

        Assert.AreEqual(this.heroRepository.GetHero(HeroName), heroToGet);

    }

    [Test]
    public void GetHero_ReturnsNull_WhenThereIsNotHeroWithTheGivenName()
    {
        this.heroRepository.Create(this.hero);

        Hero returnedHero = this.heroRepository.GetHero("Fake name");

        Assert.That(returnedHero, Is.Null);
    }

}