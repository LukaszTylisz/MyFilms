﻿using MyFilms.Domain.Common;

namespace MyFilms.Domain;

public class Movie : BaseEntity
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
    public float Rate { get; set; }
}