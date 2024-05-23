# Forberedelser
- Åpne disse fanene
  - https://htmx.org/attributes/hx-trigger/#triggering-via-the-hx-trigger-header

- Starte code with me
- Starte backenden
  ```
  $ mvn spring-boot:run
  ```

# Oppgave 1 (oven)

- Vise at add to cart gjør full page reload og at siden hopper
- Vise at WebshopController har et endepunkt for `add-to-cart` og `add-to-cart-full-reload`
- Bytte ut `<form method=post` med `<form hx-post` til `add-to-cart` 
- Vise html-responsen i network-tab i developer tools

# Oppgave 2 (Even)
- Nevne at responsen på `add-to-cart` ikke inkluderer en ny handlekurv, bare innholdet i knappen
- Ønsker at handlekurven skal oppdatere seg dynamisk når vi legger til et produkt
- Vise at vi har et endepunkt som returnerer handlekurven (`/webshop/cart`)
- Vise trigger-dokumentasjonen
- Legge til response-header i `add-to-cart`:
  ```java
  response.setHeader("HX-Trigger", "cart-updated");
  ``` 
- legge inn `hx-trigger="cart-updated from:body"`
- legge inn `hx-get="/webshop/cart"` på handlekurven (index.jsp, på cart-container)
- Cmd-F9, reload browser
- vise at det kommer hx-trigger http-header når man trykker på add to cart-knappen
- vise at det utløser en GET

# Oppgave 3 (oven)
Free shipping
- Vise endepunkt `/webshop/shipping-info`
- Legge til `<div> ` som henter shipping info
- Vise at den blir oppdatert når man legger ting i handlekurven 
- Vise at man kan laste siden på nytt, men da mangler innholdet i shipping-info
- Legge til `load` som trigger 

# Oppgave 4 (Even)
Søk
- Vise endepunkt `/webshop/search` (returnerer en ny liste av produkter, filtrert på søket)
- Koden ligger klar i index.jsp
- Legge til `hx-get="/webshop/search"`
- Legge til `hx-target="#products"`
- Forklare hx-target (Refererer id-en til elementet vi ønsker å bytte ut)
- Legge til `hx-trigger="input changed delay:300ms, search"`
- Forklare forskjellen mellom komma separert liste og ikke.


# Oppgave 5 (oven)
Vise antall på lager

- Vise endepunktet /inventory
- Legge til `<div hx-get="/inventory/productId=${product.id}" hx-trigger="load">` i products.jsp
- Vise at stock vises når siden lastes


- Vise at den dukker opp litt sent. Bør ha en loading-indikator
- Legge til `<img src="/three-dots.svg" class="htmx-indicator" />` og `hx-indicator="next img"` på `<input`  


- Legge til `HX-Trigger` header `product-updated-${product.id}` i add to cart
- Legge til `hx-trigger="load, product-updated-${product.id} from:body` 
- Vise at stock oppdaterer seg når man legger til i handlekurven
- Nevne at vi kan gjøre det samme på fjern fra handlekurven

# Oppgave 6 (Even)
Fjerne produkter fra handlekurven
- Vise endepunkt `/webshop/remove-from-cart`
- Gå til `cart.jsp` og fjern formet til remove-knapp 
- Legg til `hx-post="/webshop/remove-from-cart"` i knappen
- Legg til `name="productId"` og `value="${item.product.id}"` i knappen
- Når vi fjerner et produkt ønsker vi også å oppdatere handlekurven og lagerbeholdningen
- Må legge til response-header i `remove-from-cart`
 ```java
  response.setHeader("HX-Trigger", "cart-updated, stock-updated-" + productId);
  ``` 

Tøm handlekurven
- Vis endepunktet `/webshop/cart` (delete-mapping)
- Vi ønsker å fjerne alle produktene men også oppdatere handlekurven og lagerbeholdningen 
- Legg til i `/webshop/cart`: 
```java
List<String> events = new ArrayList<>();
// I loopen:
events.add("stock-updated-" + item.getProduct().getId());
// Etter loopen:
cart.clear();
events.add("cart-updated");
response.setHeader("HX-Trigger", String.join(", ", events));
```
- Fjern formet fra clear-knappen i cart.jsp
- Legg til `hx-delete="/webshop/cart"` i clear-knappen
- Test i nettleseren
