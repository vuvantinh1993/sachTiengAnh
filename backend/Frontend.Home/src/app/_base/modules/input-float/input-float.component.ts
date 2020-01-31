import { Component, OnInit, ViewEncapsulation, forwardRef, AfterViewInit, OnChanges, Input, Output, EventEmitter, ElementRef, SimpleChanges } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { InputNumberComponent } from '../input-number/input-number.component';
import createNumberMask from 'text-mask-addons/dist/createNumberMask';

declare let $;
@Component({
  selector: 'input-float',
  templateUrl: './input-float.component.html',
  styleUrls: ['./input-float.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => InputFloatComponent),
      multi: true,
    }
  ]
})
export class InputFloatComponent implements OnInit, AfterViewInit, ControlValueAccessor, OnChanges {
  constructor(
    private el: ElementRef
  ) { }
  @Input() class: any = '';
  @Input() placeholder: any = '';
  @Input() disabled = false;
  @Input() hidden = false;
  @Input() readonly = false;
  @Input() min: number;
  @Input() max: number;
  @Input() step = 1;
  @Input() symbol = ',';
  @Input() prefix = '';
  @Input() decimalLimit = 3;
  @Input() integerLimit: number = null;
  // tslint:disable-next-line:no-output-rename
  @Output('onChange') eventOnChange = new EventEmitter<any>();
  // tslint:disable-next-line:no-output-rename
  @Output('onBlur') eventOnBlur = new EventEmitter<void>();
  // tslint:disable-next-line:no-output-rename
  @Output('onUnBlur') eventOnUnBlur = new EventEmitter<void>();

  // tslint:disable-next-line:member-ordering
  public controlValue: number | null = null;
  public check = 1; // dung de check gia tri la min
  public maskFomat = createNumberMask({
    prefix: this.prefix,
    suffix: '',
    allowNegative: false,
    allowDecimal: true,
    decimalLimit: this.decimalLimit,
    integerLimit: this.integerLimit,
    thousandsSeparatorSymbol: this.symbol
  });
  eventBaseChange = (_: any) => { };
  eventBaseTouched = () => { };

  ngOnInit() {
  }

  ngOnChanges(changes: SimpleChanges): void {
  }

  ngAfterViewInit() {
    $(this.el.nativeElement).removeClass(this.class);
  }

  writeValue(obj: any) {
    this.controlValue = obj;
  }

  registerOnChange(fn: any) {
    this.eventBaseChange = fn;
  }

  registerOnTouched(fn: any) {
    this.eventBaseTouched = fn;
  }

  onBlur() {
    this.eventBaseTouched();
    this.eventOnBlur.emit();
  }

  onUnBlur() {
    this.onChange();
    this.eventOnUnBlur.emit();
  }

  onChange() {
    const val = this.getValue();
    this.eventBaseChange(val);
    this.eventOnChange.emit(val);
  }

  setDisabledState?(isDisabled: boolean): void {
    this.disabled = isDisabled;
  }

  pushValue() {
    const val = this.getValue();
    if (this.max && +val + this.step > this.max) {
      this.controlValue = this.max;
      this.onChange();
      return;
    }
    this.controlValue = +val + this.step;
    this.onChange();
  }

  minusValue() {
    const val = this.getValue();
    if (+val <= this.min) {
      if (this.check === 2) {
        this.controlValue = null;
      }
      this.onChange();
      return;
    }
    if (+val <= this.step) {
      this.controlValue = this.min;
      this.check++;
      this.onChange();
      return;
    }
    this.controlValue = +val - this.step;
    this.onChange();
  }

  private getValue() {
    let val: any = this.controlValue;
    if (!val) { val = ''; }
    val = val.toString().replace(new RegExp(this.symbol, 'g'), '');
    if (this.prefix !== '') {
      val = val.replace(new RegExp(this.prefix, 'g'), '');
    }
    return val;
  }
}
