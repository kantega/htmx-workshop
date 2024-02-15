package no.kantega.htmxdemo.infrastructure;

import jakarta.servlet.RequestDispatcher;
import jakarta.servlet.ServletException;
import jakarta.servlet.ServletRequest;
import jakarta.servlet.ServletResponse;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletRequestWrapper;
import org.springframework.web.servlet.view.JstlView;

import java.io.IOException;

/**
 * JSTL View som later som alle requester er GET. Det gjør at vi kan returnere HTML også fra PUT og DELETE-metoder.
 * Hvis vi ikke gjorde dette, ville den kompilerte JSP-en avvist requesten med 405 Method Not Allowed
 * <p/>
 * Slik ser JSP-filene sin service()-metode ut:
 * <p/>
 * <code>
 * <pre>
 *     public void _jspService(final javax.servlet.http.HttpServletRequest request, final javax.servlet.http.HttpServletResponse response)
 *       throws java.io.IOException, javax.servlet.ServletException
 *     {
 *         final java.lang.String _jspx_method = request.getMethod();
 *         if (!"GET".equals(_jspx_method) && !"POST".equals(_jspx_method) && !"HEAD".equals(_jspx_method) && !javax.servlet.DispatcherType.ERROR.equals(request.getDispatcherType())) {
 *             response.sendError(HttpServletResponse.SC_METHOD_NOT_ALLOWED, "JSPs only permit GET, POST or HEAD. Jasper also permits OPTIONS");
 *             return;
 *         }
 *         ...
 *     }
 * </pre>
 * </code>
 */
public class AlwaysGetMethodJstlView extends JstlView {
    @Override
    protected RequestDispatcher getRequestDispatcher(HttpServletRequest request, String path) {
        return new RequestDispatcherWrapper(super.getRequestDispatcher(request, path));
    }

    private static class RequestDispatcherWrapper implements RequestDispatcher {
        private final RequestDispatcher dispatcher;

        public RequestDispatcherWrapper(RequestDispatcher dispatcher) {
            this.dispatcher = dispatcher;
        }

        @Override
        public void forward(ServletRequest request, ServletResponse response) throws ServletException, IOException {
            dispatcher.forward(new AlwaysGetMethodRequestWrapper((HttpServletRequest) request), response);
        }

        @Override
        public void include(ServletRequest request, ServletResponse response) throws ServletException, IOException {
            dispatcher.include(request, response);
        }
    }

    private static class AlwaysGetMethodRequestWrapper extends HttpServletRequestWrapper {
        public AlwaysGetMethodRequestWrapper(HttpServletRequest request) {
            super(request);
        }

        /**
         * Returnerer alltid "GET"
         */
        @Override
        public String getMethod() {
            return "GET";
        }
    }
}
