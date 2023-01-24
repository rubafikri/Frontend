import { HttpEventType } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { environment } from 'src/environments/environment';
import { IPublisher } from '../interfaces/IPublisher';
import { PublishernewService } from '../Services/publishernew.service';

@Component({
  selector: 'app-publishernew',
  templateUrl: './publisher.component.html',
  styleUrls: ['./publisher.component.css'],
})
export class PublisherComponent implements OnInit {
  constructor(
    private publisherNewService: PublishernewService,
    private route: ActivatedRoute
  ) { }
  loadedPublisher: IPublisher[];
  AddPublisherForm: FormGroup;
  SearchForPublishers: FormGroup;
  progressValue: string;
  imageSrc: string;
  serachKey: string;
  imgSrc = environment.baseURL + '/Images/Thumbs/Med/';
  updateded: boolean = true;
  publisher: IPublisher;
  eve: Event;

  ngOnInit(): void {
    this.AddPublisherForm = new FormGroup({
      id: new FormControl('', [Validators.required]),
      name: new FormControl('', [Validators.required]),
      file: new FormControl('', [Validators.required]),
      fileSource: new FormControl('', [Validators.required]),
    });
    this.SearchForPublishers = new FormGroup({
      serachKey: new FormControl('', [Validators.required]),
    });
    this.getPublisher();
  }

  onSubmit() {
    const { name, fileSource } = this.AddPublisherForm.value;
    console.log(name, fileSource);

    this.publisherNewService.addPublisher(name, fileSource).subscribe({
      next: (data) => {
        if (data.type == HttpEventType.UploadProgress) {
          if (data.total)
            this.progressValue =
              Math.round(100 * (data.loaded / data.total)) + '%';
        }
        if (data.type == HttpEventType.Response) {
          console.log(data.body);
          this.imageSrc =
            environment.baseURL + '/Images/Thumbs/Med/' + data.body!.logo;
        }
      },
    });
  }

  onFileChange(event: Event) {
    const target = event.target as HTMLInputElement;
    const files = target.files!;

    if (files.length > 0) {
      const file = files[0];
      console.log(file);
      this.AddPublisherForm.patchValue({
        fileSource: file,
      });
    }
  }
  getPublisher() {
    this.publisherNewService.getPublishers().subscribe({
      next: (data) => {
        this.loadedPublisher = data;
        console.log(this.loadedPublisher);
      },
    });
  }

  search() {
    const { serachKey } = this.SearchForPublishers.value;
    this.route.paramMap.subscribe((params) => {
      this.serachKey = params.get('serachKey')!;
    });
    this.publisherNewService.onSearchPublisher(serachKey).subscribe({
      next: (data) => {
        console.log(data);
      },
    });
  }
  onUpdate() {
    const { name, fileSource } = this.AddPublisherForm.value;
    console.log(name, fileSource);
    this.publisherNewService.upPublisher(name, fileSource).subscribe({
      next: (data) => {
        if (data.type == HttpEventType.UploadProgress) {
          if (data.total)
            this.progressValue =
              Math.round(100 * (data.loaded / data.total)) + '%';
        }
        if (data.type == HttpEventType.Response) {
          console.log(data.body);
          this.imageSrc =
            environment.baseURL + '/Images/Thumbs/Med/' + data.body!.logo;
        }
      },

    });

    // this.publisher.name = name;
    // console.log(this.publisher);
    // this.publisherNewService.UpdatePublishers(this.publisher).subscribe({
    //   next: (data) => {
    //     this.publisher = data;
    //     console.log(this.publisher);
    //     this.getPublisher();
    //   },
    // });
    // this.AddPublisherForm.reset();
    // this.updateded = true;
  }
  populateForm(pub: IPublisher) {
    this.updateded = false;
    this.AddPublisherForm = new FormGroup({
      name: new FormControl(pub.name, [Validators.required]),
      id: new FormControl(pub.id, [Validators.required]),
      logo: new FormControl(this.imageSrc + pub.logo, [Validators.required]),
      file: new FormControl(''),
      fileSource: new FormControl(''),
    });
    this.publisher = pub;
    console.log(pub);
  }

  onDeletePublisher(id: number) {
    this.publisherNewService.deletePublisher(id).subscribe({
      next: (data) => {
        console.log(data);
        this.getPublisher();
      },
    });
  }
}
