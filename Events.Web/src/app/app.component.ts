import { Component } from '@angular/core';
import { EventService } from './services/event.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Events.Web';
  
  constructor(public eventsService: EventService){
    this.eventsService.getEvents().subscribe(r => console.log(r))
  }
}
