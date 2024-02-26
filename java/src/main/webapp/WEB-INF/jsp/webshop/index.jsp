<%@ page contentType="text/html;charset=UTF-8" %>

<%@ taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>


<t:layout>
    <div id="page-layout">
        <div id="alert" hx-trigger="load, cart-updated from:body" hx-get="/webshop/shipping-info">
        </div>

        <div id="search" class="mb-2">
            <label>
                Search:
                <input type="search" class="form-control form-control-sm"
                       hx-trigger="keyup delay:250ms, search, changed delay:500ms"
                       hx-get="/webshop/search"
                       hx-target="#products"
                       name="q">
            </label>
        </div>

        <div id="products">
            <%@ include file="products.jsp" %>
        </div>
        <div id="cart" hx-trigger="cart-updated from:body" hx-get="/webshop/cart">
            <%@ include file="cart.jsp" %>
        </div>
    </div>
</t:layout>
