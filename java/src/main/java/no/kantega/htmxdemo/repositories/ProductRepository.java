package no.kantega.htmxdemo.repositories;

import no.kantega.htmxdemo.domain.Price;
import no.kantega.htmxdemo.domain.Product;
import org.springframework.stereotype.Component;

import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Component
public class ProductRepository {

    List<Product> products = new ArrayList<>();

    static int nextId = 1;

    public ProductRepository() {
        // Adding sample product data to the list
        products.add(createProduct("Snatch (2000) Blueray", "Snatch is a 2000 British-American crime comedy film written and directed by Guy Ritchie, featuring an ensemble cast. Set in the London criminal underworld.", "199.99", "https://upload.wikimedia.org/wikipedia/en/thumb/a/a7/Snatch_ver4.jpg/320px-Snatch_ver4.jpg"));
        products.add(createProduct("Forrest Gump (1994) DVD", "Forrest Gump is a 1994 American epic comedy-drama film directed by Robert Zemeckis and written by Eric Roth. It is based on the 1986 novel of the same name by Winston Groom and stars Tom Hanks, Robin Wright, Gary Sinise, Mykelti Williamson and Sally Field.", "129.49", "https://upload.wikimedia.org/wikipedia/en/6/67/Forrest_Gump_poster.jpg"));
        products.add(createProduct("The Matrix (1999) Blueray", "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis. It is the first installment in the Matrix film series, starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano.", "99.99", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg"));
        products.add(createProduct("Pulp Fiction (1994) Blueray", "Pulp Fiction is a 1994 American crime film written and directed by Quentin Tarantino, who conceived it with Roger Avary. Starring John Travolta, Samuel L. Jackson, Bruce Willis, Tim Roth, Ving Rhames, and Uma Thurman.", "399.00", "https://upload.wikimedia.org/wikipedia/en/3/3b/Pulp_Fiction_%281994%29_poster.jpg"));
        products.add(createProduct("Reservoir Dogs (1992) DVD", "Reservoir Dogs is a 1992 American neo-noir crime film written and directed by Quentin Tarantino in his feature-length debut. It stars Harvey Keitel, Tim Roth, Chris Penn, Steve Buscemi, Lawrence Tierney, Michael Madsen, Tarantino, and Edward Bunker.", "250.00", "https://upload.wikimedia.org/wikipedia/en/0/01/Reservoir_Dogs.png"));
        products.add(createProduct("The Crow (1994) DVD", "The Crow is a 1994 American superhero film directed by Alex Proyas, written by David J. Schow and John Shirley. It stars Brandon Lee, in his final film appearance, as Eric Draven, a murdered musician who is resurrected to avenge his death and that of his fiancée.", "189.99", "https://upload.wikimedia.org/wikipedia/en/3/39/Crow_ver2.jpg"));
        products.add(createProduct("Don't Drink the Water (1994) Blueray", "Don't Drink the Water is a 1994 American made-for-television comedy film written and directed by Woody Allen, based on his 1966 play. This is the second filmed version of the play.", "39.99", "https://upload.wikimedia.org/wikipedia/en/d/d9/Dont_Drink_the_Water_1994.jpg"));
        products.add(createProduct("Dumb and Dumber (1994) DVD", "Dumb and Dumber is a 1994 American buddy comedy film directed by Peter Farrelly, who cowrote the screenplay with Bobby Farrelly and Bennett Yellin. It is the first installment in the Dumb and Dumber franchise.", "69.00", "https://upload.wikimedia.org/wikipedia/en/6/64/Dumbanddumber.jpg"));
        products.add(createProduct("Die Hard with a Vengeance (1995) DVD", "Die Hard with a Vengeance is a 1995 American action thriller film directed by John McTiernan. It was written by Jonathan Hensleigh, based on the screenplay Simon Says by Hensleigh and on the characters created by Roderick Thorp for his 1979 novel Nothing Lasts Forever.", "109.99", "https://upload.wikimedia.org/wikipedia/en/4/4c/Die_Hard_With_A_Vengance.jpg"));
        products.add(createProduct("Home Alone (1990) DVD", "Home Alone is a 1990 Christmas comedy film directed by Chris Columbus and written and produced by John Hughes. The first film in the Home Alone franchise, the film stars Macaulay Culkin, Joe Pesci, Daniel Stern, John Heard, and Catherine O'Hara.", "59.90", "https://upload.wikimedia.org/wikipedia/en/7/76/Home_alone_poster.jpg"));
        products.add(createProduct("Goodfellas (1990) Blueray", "Goodfellas is a 1990 American biographical crime film directed by Martin Scorsese, written by Nicholas Pileggi and Scorsese, and produced by Irwin Winkler. It is a film adaptation of the 1985 nonfiction book Wiseguy by Pileggi.", "390.00", "https://upload.wikimedia.org/wikipedia/en/7/7b/Goodfellas.jpg"));
        products.add(createProduct("Memento (2000) Blueray", "Memento is a 2000 American neo-noir psychological thriller film written and directed by Christopher Nolan, based on the short story Memento Mori by his brother Jonathan Nolan, which was later published in 2001.", "99.00", "https://upload.wikimedia.org/wikipedia/en/c/c7/Memento_poster.jpg"));
        products.add(createProduct("The Gift (2000) DVD", "The Gift is a 2000 American supernatural horror thriller film directed by Sam Raimi, written by Billy Bob Thornton and Tom Epperson, and based on the alleged psychic experiences of Thornton's mother.", "499.00", "https://upload.wikimedia.org/wikipedia/en/9/95/The_Gift_%282000_film%29.jpg"));
        products.add(createProduct("Erin Brockovich (2000) Blueray", "Erin Brockovich is a 2000 American biographical legal drama film directed by Steven Soderbergh and written by Susannah Grant. The film is a dramatization of the true story of Erin Brockovich, portrayed by Julia Roberts.", "189.99", "https://upload.wikimedia.org/wikipedia/en/a/a9/Erin_Brockovich_%28film_poster%29.jpg"));
        products.add(createProduct("V for Vendetta (2006) DVD", "V for Vendetta is a 2005 dystopian political action film directed by James McTeigue from a screenplay by the Wachowskis. It is based on the 1988 DC Vertigo Comics limited series of the same title by Alan Moore, David Lloyd, and Tony Weare.", "99.99", "https://upload.wikimedia.org/wikipedia/en/9/9f/Vforvendettamov.jpg"));
        products.add(createProduct("Little Miss Sunshine (2006) Blueray", "Little Miss Sunshine is a 2006 American tragicomedy road film and the feature film directorial debut of the husband–wife team of Jonathan Dayton and Valerie Faris. The screenplay was written by first-time writer Michael Arndt.", "299.00", "https://upload.wikimedia.org/wikipedia/en/1/16/Little_miss_sunshine_poster.jpg"));
        products.add(createProduct("Man on Fire (2004) DVD", "Man on Fire is a 2004 action thriller film directed by Tony Scott from a screenplay by Brian Helgeland, and based on the 1980 novel of the same name by A. J. Quinnell.", "179.00", "https://upload.wikimedia.org/wikipedia/en/e/e8/Man_on_fireposter.jpg"));
        products.add(createProduct("The Departed (2006) Blueray", "The Departed is a 2006 American epic crime thriller film directed by Martin Scorsese and written by William Monahan. It is both a remake of the 2002 Hong Kong film Infernal Affairs and also loosely based on the real-life Boston Winter Hill Gang.", "129.99", "https://upload.wikimedia.org/wikipedia/en/5/50/Departed234.jpg"));
        products.add(createProduct("Avatar (2009) Blueray", "Avatar is a 2009 epic science fiction film directed, written, co-produced, and co-edited by James Cameron and starring Sam Worthington, Zoe Saldana, Stephen Lang, Michelle Rodriguez, and Sigourney Weaver. It is the first installment in the Avatar film series.", "269.49", "https://upload.wikimedia.org/wikipedia/en/d/d6/Avatar_%282009_film%29_poster.jpg"));
        products.add(createProduct("The Curious Case of Benjamin Button", "The Curious Case of Benjamin Button is a 2008 American fantasy romantic drama film directed by David Fincher. The storyline by Eric Roth and Robin Swicord is loosely based on the 1922 short story of the same name by F. Scott Fitzgerald.", "129.00", "https://upload.wikimedia.org/wikipedia/en/7/7c/The_Curious_Case_of_Benjamin_Button_%28film%29.png"));
    }

    private static Product createProduct(String name, String description, String price, String image) {
        Product product = new Product(nextId++, name, description, price, image);
        for (int i = 1; i < 6; i++) {
            product.addPrice(new Price(LocalDate.now().minusMonths(i), new BigDecimal(price).subtract(new BigDecimal(10 * i))));
        }
        return product;
    }

    public List<Product> findAll() {
        return products;
    }

    public Product findById(int id) {
        return products.stream().filter(p -> p.getId() == id).findFirst().orElse(null);
    }

    public List<Product> findByName(String name) {
        return products.stream()
                .filter(p -> p.getName().toLowerCase().contains(name))
                .toList();
    }
}
