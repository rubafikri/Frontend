import { Component, OnInit } from '@angular/core';
import { IPublisher } from 'src/app/AdminComponent/Admin/interfaces/IPublisher';
import { PublishernewService } from 'src/app/AdminComponent/Admin/Services/publishernew.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-publishers',
  templateUrl: './publishers.component.html',
  styleUrls: ['./publishers.component.css'],
})
export class PublishersComponent implements OnInit {
  loadedpublisher: IPublisher[];
  getpublisherlist: IPublisher[];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  get: boolean = false;
  constructor(private publisheService: PublishernewService) {}

  ngOnInit(): void {
    this.getPublisher();
  }
  getPublisher() {
    this.publisheService.getPublishers().subscribe({
      next: (data) => {
        this.loadedpublisher = data;
        this.get = true;
        this.getpublisherlist = this.loadedpublisher.slice(0, 6);
      },
    });
  }
}
