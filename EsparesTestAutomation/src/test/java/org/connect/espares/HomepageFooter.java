package org.connect.espares;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;
import resources.DriverInitializer;

import java.io.IOException;
import java.util.Iterator;
import java.util.Set;

public class HomepageFooter extends DriverInitializer {

    WebDriver driver;

    @BeforeMethod
    public void setUpTest() throws IOException {
        driver = initialize();
        driver.get(prop.getProperty("url"));
    }

    @Test
    public void footerLinkValidation() throws InterruptedException {
        System.out.println(driver.findElements(By.tagName("a")).size());
        WebElement footerDriver= driver.findElement(By.cssSelector(".footer-wrapper"));
        System.out.println(footerDriver.findElements(By.tagName("a")).size());
        String skipTagTitle = "Cookie Settings";
        for (int i=1;i<footerDriver.findElements(By.tagName("a")).size();i++) {
            String tagTitle = footerDriver.findElements(By.tagName("a")).get(i).getText();
            if(!skipTagTitle.equals(tagTitle)) {
                System.out.println(tagTitle + " -- test title from inside");
                String clickonlinkTab=Keys.chord(Keys.CONTROL,Keys.ENTER);
                footerDriver.findElements(By.tagName("a")).get(i).sendKeys(clickonlinkTab);
            }else {
                System.out.println(tagTitle);
            }
            Thread.sleep(2000L);
        }
        Set<String> abc=driver.getWindowHandles();
        Iterator<String> it=abc.iterator();
        while(it.hasNext())
        {
            System.out.println(driver.getTitle());
            driver.switchTo().window(it.next());
            Thread.sleep(3000L);

        }
    }

    @AfterMethod
    public void tearDown() {
        driver.quit();
    }

}
