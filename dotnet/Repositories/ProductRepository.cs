using System;
using System.Xml.Linq;
using htmx_test.Controllers;
using htmx_test.Models;
using static System.Net.WebRequestMethods;

namespace htmx_test.Repositories
{
	public class ProductRepository
	{
		private List<Product> _products;

        public ProductRepository()
		{
            _products = new List<Product>
                {
                    new Product { ID = 1, Name = "Snatch (2000) Blueray", Description = "Snatch is a 2000 British-American crime comedy film written and directed by Guy Ritchie, featuring an ensemble cast. Set in the London criminal underworld.", Price = 199.99m, Image = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a7/Snatch_ver4.jpg/320px-Snatch_ver4.jpg"},
                    new Product { ID = 2, Name = "Forrest Gump (1994) DVD", Description = "Forrest Gump is a 1994 American epic comedy-drama film directed by Robert Zemeckis and written by Eric Roth. It is based on the 1986 novel of the same name by Winston Groom and stars Tom Hanks, Robin Wright, Gary Sinise, Mykelti Williamson and Sally Field.", Price = 129.49m, Image = "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg" },
                    new Product { ID = 3, Name = "The Matrix (1999) Blueray", Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis. It is the first installment in the Matrix film series, starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano.", Price = 99.99m, Image = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg" },
                    new Product { ID = 4, Name = "Pulp Fiction (1994) Blueray", Description = "Pulp Fiction is a 1994 American crime film written and directed by Quentin Tarantino, who conceived it with Roger Avary. Starring John Travolta, Samuel L. Jackson, Bruce Willis, Tim Roth, Ving Rhames, and Uma Thurman.", Price = 399.00m, Image = "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg" },
                    new Product { ID = 5, Name = "Reservoir Dogs (1992) DVD", Description = "Reservoir Dogs is a 1992 American neo-noir crime film written and directed by Quentin Tarantino in his feature-length debut. ", Price = 250.00m, Image = "https://upload.wikimedia.org/wikipedia/en/0/01/Reservoir_Dogs.png" },
                    new Product { ID = 6, Name = "The Crow (1994) DVD", Description = "The Crow is a 1994 American superhero film directed by Alex Proyas, written by David J. Schow and John Shirley. It stars Brandon Lee, in his final film appearance, as Eric Draven, a murdered musician who is resurrected to avenge his death and that of his fiancée.", Price = 189.99m, Image = "https://upload.wikimedia.org/wikipedia/en/3/39/Crow_ver2.jpg" },
                    new Product { ID = 7, Name = "Don't Drink the Water (1994) Blueray", Description = "Don't Drink the Water is a 1994 American made-for-television comedy film written and directed by Woody Allen, based on his 1966 play. This is the second filmed version of the play.", Price = 39.99m, Image = "https://upload.wikimedia.org/wikipedia/en/d/d9/Dont_Drink_the_Water_1994.jpg" },
                    new Product { ID = 8, Name = "Dumb and Dumber (1994) DVD", Description = "Dumb and Dumber is a 1994 American buddy comedy film directed by Peter Farrelly, who cowrote the screenplay with Bobby Farrelly and Bennett Yellin. It is the first installment in the Dumb and Dumber franchise.", Price = 69.00m, Image = "https://upload.wikimedia.org/wikipedia/en/6/64/Dumbanddumber.jpg"},
                    new Product { ID = 9, Name = "Die Hard with a Vengeance (1995) DVD", Description = "Die Hard with a Vengeance is a 1995 American action thriller film directed by John McTiernan. It was written by Jonathan Hensleigh, based on the screenplay Simon Says by Hensleigh.", Price = 109.99m, Image = "https://upload.wikimedia.org/wikipedia/en/4/4c/Die_Hard_With_A_Vengance.jpg"},
                    new Product { ID = 10, Name = "Home Alone (1990) DVD", Description = "Home Alone is a 1990 Christmas comedy film directed by Chris Columbus and written and produced by John Hughes. The first film in the Home Alone franchise, the film stars Macaulay Culkin, Joe Pesci, Daniel Stern, John Heard, and Catherine O'Hara.", Price = 59.90m, Image = "https://upload.wikimedia.org/wikipedia/en/7/76/Home_alone_poster.jpg"},
                    new Product { ID = 11, Name = "Goodfellas (1990) Blueray", Description = "Goodfellas is a 1990 American biographical crime film directed by Martin Scorsese, written by Nicholas Pileggi and Scorsese, and produced by Irwin Winkler. It is a film adaptation of the 1985 nonfiction book Wiseguy by Pileggi.", Price = 390.00m, Image = "https://upload.wikimedia.org/wikipedia/en/7/7b/Goodfellas.jpg" },
                    new Product { ID = 12, Name = "Memento (2000) Blueray", Description = "Memento is a 2000 American neo-noir psychological thriller film written and directed by Christopher Nolan, based on the short story Memento Mori by his brother Jonathan Nolan, which was later published in 2001.", Price = 99.00m, Image = "https://upload.wikimedia.org/wikipedia/en/c/c7/Memento_poster.jpg" },
                    new Product { ID = 13, Name = "The Gift (2000) DVD", Description = "The Gift is a 2000 American supernatural horror thriller film directed by Sam Raimi, written by Billy Bob Thornton and Tom Epperson, and based on the alleged psychic experiences of Thornton's mother.", Price = 499.00m, Image = "https://upload.wikimedia.org/wikipedia/en/9/95/The_Gift_%282000_film%29.jpg" },
                    new Product { ID = 14, Name = "Erin Brockovich (2000) Blueray", Description= "Erin Brockovich is a 2000 American biographical legal drama film directed by Steven Soderbergh and written by Susannah Grant. The film is a dramatization of the true story of Erin Brockovich.", Price = 189.99m, Image = "https://upload.wikimedia.org/wikipedia/en/a/a9/Erin_Brockovich_%28film_poster%29.jpg" },
                    new Product { ID = 15, Name = "V for Vendetta (2006) DVD", Description = "V for Vendetta is a 2005 dystopian political action film directed by James McTeigue from a screenplay by the Wachowskis. It is based on the 1988 DC Vertigo Comics limited series of the same title by Alan Moore, David Lloyd, and Tony Weare.", Price = 99.99m, Image = "https://upload.wikimedia.org/wikipedia/en/9/9f/Vforvendettamov.jpg" },
                    new Product { ID = 16, Name = "Little Miss Sunshine (2006) Blueray", Description = "Little Miss Sunshine is a 2006 American tragicomedy road film and the feature film directorial debut of the husband–wife team of Jonathan Dayton and Valerie Faris. The screenplay was written by first-time writer Michael Arndt.", Price = 299.00m, Image = "https://upload.wikimedia.org/wikipedia/en/1/16/Little_miss_sunshine_poster.jpg" },
                    new Product { ID = 17, Name = "Man on Fire (2004) DVD", Description = "Man on Fire is a 2004 action thriller film directed by Tony Scott from a screenplay by Brian Helgeland, and based on the 1980 novel of the same name by A. J. Quinnell.", Price = 179.00m, Image = "https://upload.wikimedia.org/wikipedia/en/e/e8/Man_on_fireposter.jpg" },
                    new Product { ID = 18, Name = "The Departed (2006) Blueray", Description = "The Departed is a 2006 American epic crime thriller film directed by Martin Scorsese and written by William Monahan. It is both a remake of the 2002 Hong Kong film Infernal Affairs and also loosely based on the real-life Boston Winter Hill Gang.", Price = 129.99m, Image = "https://upload.wikimedia.org/wikipedia/en/5/50/Departed234.jpg" },
                    new Product { ID = 19, Name = "Avatar (2009) Blueray", Description = "Avatar is a 2009 epic science fiction film directed, written, co-produced, and co-edited by James Cameron and starring Sam Worthington, Zoe Saldana, Stephen Lang, Michelle Rodriguez, and Sigourney Weaver. It is the first installment in the Avatar film series.", Price = 269.49m, Image = "https://upload.wikimedia.org/wikipedia/en/d/d6/Avatar_%282009_film%29_poster.jpg" },
                    new Product { ID = 20, Name = "The Curious Case of Benjamin Button (2008) DVD", Description = "The Curious Case of Benjamin Button is a 2008 American fantasy romantic drama film directed by David Fincher. The storyline by Eric Roth and Robin Swicord is loosely based on the 1922 short story of the same name by F. Scott Fitzgerald.", Price = 129.00m, Image = "https://upload.wikimedia.org/wikipedia/en/7/7c/The_Curious_Case_of_Benjamin_Button_%28film%29.png" },

                };
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product FindProductById(int productID)
        {
            return _products.FirstOrDefault(p => p.ID == productID);
        }

        public IEnumerable<Product> findByName(String q)
        {
           return _products.Where(p => p.Name.ToLower().Contains(q.ToLower())).ToList();
        }
    }
}

