import { Component, OnInit } from '@angular/core';
import { IStaticPages } from 'src/app/AdminComponent/Admin/interfaces/IstaticPages';
import { StaticPagesService } from 'src/app/AdminComponent/Admin/Services/StaticPages.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css'],
})
export class AboutComponent implements OnInit {
  staticPage: IStaticPages[];
  constructor(private staticPageService: StaticPagesService) {}

  ngOnInit(): void {
    this.getStaticPages();
  }

  getStaticPages() {
    return this.staticPageService.getStaticPages('من نحن').subscribe({
      next: (data) => {
        this.staticPage = data;
        console.log(this.staticPage);
      },
    });
  }
}
