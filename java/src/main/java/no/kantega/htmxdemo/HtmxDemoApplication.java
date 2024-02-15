package no.kantega.htmxdemo;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import no.kantega.htmxdemo.infrastructure.AlwaysGetMethodJstlView;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.web.servlet.LocaleResolver;
import org.springframework.web.servlet.ViewResolver;
import org.springframework.web.servlet.view.InternalResourceViewResolver;

import java.util.Locale;

@SpringBootApplication
public class HtmxDemoApplication {
	public static void main(String[] args) {
		Locale.setDefault(new Locale("no", "no"));
		SpringApplication.run(HtmxDemoApplication.class, args);
	}

	@Bean
	public LocaleResolver localeResolver() {
		return new LocaleResolver() {
			@Override
			public Locale resolveLocale(HttpServletRequest request) {
				return Locale.getDefault();
			}

			@Override
			public void setLocale(HttpServletRequest request, HttpServletResponse response, Locale locale) {
			}
		};
	}

	@Bean
	public ViewResolver internalResourceViewResolver() {
		InternalResourceViewResolver bean = new InternalResourceViewResolver();
		bean.setViewClass(AlwaysGetMethodJstlView.class);
		bean.setPrefix("/WEB-INF/jsp/");
		bean.setSuffix(".jsp");
		return bean;
	}
}
