<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<fmt:setLocale value="no-NO"/>
<h2>Shopping cart</h2>
<c:choose>
    <c:when test="${empty cart.items}">
        <p>cart is empty</p>
    </c:when>
    <c:otherwise>
        <table class="table table-striped">
            <thead>
            <tr>
                <th>Product</th>
                <th class="text-end">Qty</th>
                <th class="text-end">Sum</th>
            </tr>
            </thead>
            <tbody>

            <c:forEach var="item" items="${cart.items}">
                <tr>
                    <td>${item.product.name}</td>
                    <td class="text-end">${item.quantity}</td>
                    <td class="text-end"><fmt:formatNumber value="${item.sum}" type="currency"/></td>
                    <td>
                        <form action="/webshop/remove-from-cart-full-reload" method="post">
                            <input type="hidden" name="productId" value="${item.product.id}">
                            <button class="btn btn-sm btn-outline-danger">Remove</button>
                        </form>
                    </td>
                </tr>
            </c:forEach>
            <tr>
                <th colspan="2">Total</th>
                <th class="text-end"><fmt:formatNumber value="${cart.total}" type="currency"/></th>
                <th></th>
            </tr>
            </tbody>
        </table>

        <form action="/webshop/clear-cart-full-reload" method="post">
            <button class="btn btn-danger">Clear</button>
        </form>
    </c:otherwise>
</c:choose>
