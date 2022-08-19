using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
        }
       
        [Test]
        [TestCase("Nemo")]
        [TestCase("Riba1")]
        [TestCase("Riba2")]
        public void TestIfItemConstructorSetsOwnerAndID(string name)
        {
            Item item = new Item(name, "tintiri");

            Assert.AreEqual(item.Owner, name);
            Assert.AreEqual(item.ItemId, "tintiri");
        }

        [Test]
        public void ConstructorShouldCreateDictionaryWithNullValues()
        {
            Assert.That(vault.VaultCells.Values.All(v => v == null));
        }

        [Test]
        public void ConstructorShouldThrowExceptionNonExistentCell()
        {
            Assert.Throws<ArgumentException>(() => vault.AddItem("D1", new Item("Petar", "4632DM")));
        }

        [Test]
        public void ConstructorShouldThrowExceptionTakenCell()
        {
            vault.AddItem("B1", new Item("Petar", "4632DM"));
            Assert.Throws<ArgumentException>(() => vault.AddItem("B1", new Item("Gosho", "23ID")));
        }

        [Test]
        public void ConstructorShouldThrowExceptionSameItem()
        {
            vault.AddItem("B1", new Item("Petar", "4632DM"));
            Assert.Throws<InvalidOperationException>(() => vault.AddItem("A1", new Item("Petar", "4632DM")));
        }

        [Test]
        public void AddMethodShouldAddItemInEmptyCell()
        {
            vault.AddItem("A1", new Item("Petar", "4632DM"));
            Assert.That(vault.VaultCells["A1"] != null);
        }

        [Test]
        public void AddMethodShouldReturnCorrectMessage()
        {
            string message = vault.AddItem("A1", new Item("Petar", "4632DM"));

            Assert.AreEqual($"Item:4632DM saved successfully!", message);
        }


        [Test]
        public void RemoveShouldThrowExceptionNonExistentCell()
        {
            Item item1 = new Item("Petar", "4632DM");
            Item item2 = new Item("Gosho", "23ID");

            vault.AddItem("A1", item1);

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("D1", item2));
        }

        [Test]
        public void RemoveShouldThrowExceptionNonExistentItem()
        {
            Item item1 = new Item("Petar", "4632DM");
            Item item2 = new Item("Gosho", "23ID");

            vault.AddItem("A1", item1);

            Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1", item2));
        }

        [Test]
        public void RemoveShouldWorkCorrectly()
        {
            Item item1 = new Item("Petar", "4632DM");
            Item item2 = new Item("Gosho", "23ID");

            vault.AddItem("A1", item1);
            Assert.That(vault.VaultCells["A1"] == item1);

            vault.RemoveItem("A1", item1);

            Assert.That(vault.VaultCells["A1"] == null);
        }

    }
}