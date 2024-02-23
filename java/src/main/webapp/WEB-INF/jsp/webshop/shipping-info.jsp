<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ taglib prefix="fmt" uri="http://java.sun.com/jsp/jstl/fmt" %>

<fmt:setLocale value="no-NO"/>
<c:choose>
    <c:when test="${freeShipping}">
        <div class="alert alert-success">
        You get free shipping on this order!
        </div>
    </c:when>
    <c:otherwise>
        <div class="alert alert-danger">
                Shop for ${remaining} more to get free shipping on this order
        </div>
    </c:otherwise>
</c:choose>
