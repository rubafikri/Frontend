import { Component, OnInit } from '@angular/core';
import { IPublisher } from 'src/app/AdminComponent/Admin/interfaces/IPublisher';
import { PublishernewService } from 'src/app/AdminComponent/Admin/Services/publishernew.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-publisher-list',
  templateUrl: './publisher-list.component.html',
  styleUrls: ['./publisher-list.component.css'],
})
export class PublisherListComponent implements OnInit {
  loadedpublisher: IPublisher[];
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  constructor(private publisheService: PublishernewService) {}

  ngOnInit(): void {
    this.getPublisher();
  }
  getPublisher() {
    this.publisheService.getPublishers().subscribe({
      next: (data) => {
        this.loadedpublisher = data;
        console.log(this.loadedpublisher);
      },
    });
  }
}
