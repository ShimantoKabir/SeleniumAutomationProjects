package org.connect.espares;

import org.openqa.selenium.By;
import org.openqa.selenium.JavascriptExecutor;
import org.openqa.selenium.WebDriver;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import resources.DriverInitializer;

import java.io.IOException;

public class EsparesNews extends DriverInitializer {

    WebDriver driver;

    @BeforeMethod
    public void setUpTest() throws IOException {
        driver = initialize();
        driver.get(prop.getProperty("url"));
    }

    @Test
    public void newsForm() {
        driver.findElement(By.id("subscribe-email")).sendKeys("email@espare.com");
        driver.findElement(By.id("subscribe-name")).sendKeys("Test");
        JavascriptExecutor js = null;
        if (driver instanceof JavascriptExecutor) {
            js = (JavascriptExecutor) driver;
        }
        if (js != null) {
            js.executeScript("return document.querySelectorAll('.captcha').forEach(el => el.remove());");
        }
        driver.findElement(By.xpath("//*[@id=\"EmailSignupForm\"]/div[2]/span[1]")).click();
    }

    @AfterMethod
    public void tearDown() {
        driver.quit();
    }

}
