<%@ page contentType="text/html;charset=UTF-8" %>

<%@ taglib prefix="t" tagdir="/WEB-INF/tags" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<t:layout>
    <div id="page-layout">
        <div id="banner">
            <!-- place the shipping info banner here -->
        </div>

        <div id="search" class="mb-2">
            <!-- uncomment this to add search function
            <label>
                Search:
                <input type="search" class="form-control form-control-sm"
                       name="q">
            </label>
            -->
        </div>

        <div id="products">
            <%@ include file="products.jsp" %>
        </div>
        <div id="cart">
            <div id="cart-container">
                <%@ include file="cart.jsp" %>
            </div>
        </div>
    </div>
</t:layout>
