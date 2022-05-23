import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SfBarcodeComponent } from './sf-barcode.component';

describe('SfBarcodeComponent', () => {
  let component: SfBarcodeComponent;
  let fixture: ComponentFixture<SfBarcodeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SfBarcodeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SfBarcodeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
