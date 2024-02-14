<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" %>

<span class="ps-2 small text-muted">
    <c:choose>
        <c:when test="${itemsInStock < 10}">
            <c:set var="color" value="red"/>
        </c:when>
        <c:when test="${itemsInStock < 20}">
            <c:set var="color" value="orange"/>
        </c:when>
        <c:otherwise>
            <c:set var="color" value="green"/>
        </c:otherwise>
    </c:choose>

    <i class="bi bi-circle-fill" style="color: ${color}"></i> ${itemsInStock} pcs in stock
</span>
