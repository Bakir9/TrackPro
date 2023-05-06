import { ChangeDetectorRef, Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { Router } from '@angular/router';
import {BreakpointObserver } from '@angular/cdk/layout';
import { ChangeDetectionStrategy } from '@angular/compiler';


@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent {
  @ViewChild(MatSidenav) sidenav!:MatSidenav;
  menuitems = ['dashboard','sales', 'orders', 'customers', 'products'];
  loading = true;
  constructor(private observer: BreakpointObserver, private router: Router, private cd: ChangeDetectorRef) {}

  ngAfterViewInit() {
    this.loading = false;
    this.cd.detectChanges();
    this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
      if(res.matches){
        this.sidenav.mode = 'over';
        this.sidenav.close();
      } else {
        this.sidenav.mode = 'side';
        this.sidenav.open();
      }
    });
  }
}