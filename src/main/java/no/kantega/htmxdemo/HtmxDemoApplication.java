package no.kantega.htmxdemo;

import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.web.servlet.LocaleResolver;

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
}
