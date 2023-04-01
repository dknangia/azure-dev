import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";


@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  public forecasts?: IWeatherForecast[];
  public apiUrl = "https://localhost:40443";
  constructor(http: HttpClient) {
    http.get<IWeatherForecast[]>(`/GetWeather`).subscribe(result => {
        this.forecasts = result;
      },
      error => console.error(error));
  }

  public title = "HealthCheck";
}

interface IWeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
