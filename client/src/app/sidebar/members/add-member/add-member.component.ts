import { Component, Inject, OnInit } from '@angular/core';
import {
  MAT_MOMENT_DATE_FORMATS,
  MomentDateAdapter,
  MAT_MOMENT_DATE_ADAPTER_OPTIONS,
} from '@angular/material-moment-adapter';
import { FormGroup } from '@angular/forms';
import { MembersService } from '../members.service';
import { MatDialogRef } from '@angular/material/dialog';
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import 'moment/locale/ja';
import 'moment/locale/fr';

@Component({
  selector: 'app-add-member',
  templateUrl: './add-member.component.html',
  styleUrls: ['./add-member.component.scss'],
  providers: [
    // The locale would typically be provided on the root module of your application. We do it at
    // the component level here, due to limitations of our example generation script.
    {provide: MAT_DATE_LOCALE, useValue: 'ja-JP'},
    // `MomentDateAdapter` and `MAT_MOMENT_DATE_FORMATS` can be automatically provided by importing
    // `MatMomentDateModule` in your applications root module. We provide it at the component level
    // here, due to limitations of our example generation script.
    {
      provide: DateAdapter,
      useClass: MomentDateAdapter,
      deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS],
    },
    {provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
  ],
})
export class AddMemberComponent implements OnInit {
  memberForm: FormGroup

  constructor(
    private memberService: MembersService, 
    private dialogRef: MatDialogRef<AddMemberComponent>, 
    private _adapter:DateAdapter<any>,
    @Inject(MAT_DATE_LOCALE) private _locale: string,
    ){}

  french() {
    this._locale = 'fr';
    this._adapter.setLocale(this._locale);
  }

  getDateFormatString(): string {
    if (this._locale === 'ja-JP') {
      return 'YYYY/MM/DD';
    } else if (this._locale === 'fr') {
      return 'DD/MM/YYYY';
    }
    return '';
  }

  ngOnInit(): void {}
  
  onFormSubmit(){
    this.memberService.createUser(this.memberForm.value).subscribe({
      next: (val: any) => {
        this.dialogRef.close(true);
      },
      error(error:any){
        console.error(error);
      }
    })
  }
}
