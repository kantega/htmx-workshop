<%@ taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<style>
    #page-layout {
        display: grid;
        grid-template-areas: "products cart";
        grid-column-gap: 20px;
    }
</style>

<t:layout>
    <div id="page-layout">
        <div id="products">
            <c:forEach var="product" items="${products}">
                <div class="card mb-2">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <div>
                            <h3>${product.name}</h3>
                        </div>
                        <div>
                            <fmt:formatNumber value="${product.price}" type="currency"/>
                        </div>
                    </div>
                    <div class="card-body">
                        <p>${product.description}</p>
                        <div>
                            <form>
                                <input type="hidden" name="productId" value="${product.id}">

                                <button class="btn btn-primary"
                                        hx-post="/webshop/add-to-cart"
                                        hx-target="#cart"
                                        hx-swap="innerHTML"
                                >
                                    <i class="bi bi-cart-plus"></i>
                                    Add to cart
                                </button>
                            </form>
                        </div>
                    </div>
                </div>
            </c:forEach>
        </div>
        <div id="cart">
            <%@ include file="cart.jsp" %>
        </div>
    </div>
</t:layout>
