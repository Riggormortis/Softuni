﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public string Title { get; private set; }

        public int Year { get; private set; }

        public List<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public int CompareTo(Book other)
        {
            int result = this.Year.CompareTo(other.Year);
            if (result == 0)
            {
                return this.Title.CompareTo(other.Title);
            }

            return result;
        }


        //primer dylgo kak moje da se polzva
        //if (this.Title.Length < other.Title.Length)
        //{
        //    return -1;
        //}
        //else if (this.Title.Length> other.Title.Length)
        //{
        //    return 1;
        //}
        //else
        //{
        //    return 0;
        //}

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }

    }
}

