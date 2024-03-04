<%@ page contentType="text/html;charset=UTF-8" %>

<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<%--@elvariable id="products" type="java.util.List<no.kantega.htmxdemo.domain.Product>"--%>

<div>
    <c:if test="${empty products}">
        No products found
    </c:if>
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
            <div class="card-body product-layout">
                <div class="product-image">
                    <img src="/${product.image}"/>
                </div>
                <div class="product-description">
                    <p>${product.description}</p>
                </div>
                <div class="product-stock">

                </div>
                <div class="product-addtobasket">
                    <form method="post" action="/webshop/add-to-cart-full-reload">
                        <input type="hidden" name="productId" value="${product.id}">

                        <button class="btn btn-primary mt-4">
                            <i class="bi bi-cart-plus"></i>
                            Add to cart
                        </button>
                    </form>
                </div>
            </div>
        </div>
    </c:forEach>
</div>
