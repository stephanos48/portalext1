import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './_modules/shared.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberCardComponent } from './members/member-card/member-card.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { NgxSpinnerModule } from 'ngx-spinner';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { PhotoEditorComponent } from './members/photo-editor/photo-editor.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { MemberMessagesComponent } from './members/member-messages/member-messages.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { PhotoManagementComponent } from './admin/photo-management/photo-management.component';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { HasRoleDirective } from './_directives/has-role.directive';
import { RolesModalComponent } from './modals/roles-modal/roles-modal.component';
import { ConfirmDialogComponent } from './modals/confirm-dialog/confirm-dialog.component';
import { LandingComponent } from './landing/landing.component';
import { TxqohComponent } from './inventory/txqoh/txqoh.component';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatHeaderRow, MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { TxqohCreateComponent } from './inventory/txqoh-create/txqoh-create.component';
import { TxqohEditComponent } from './inventory/txqoh-edit/txqoh-edit.component';
import { TxqohModalComponent } from './inventory/txqoh-modal/txqoh-modal.component';
import { PurchaseordersComponent } from './supplychain/purchaseorders/purchaseorders.component';
import { PoplanModalComponent } from './supplychain/poplan-modal/poplan-modal.component';
import { PoplanCreateComponent } from './supplychain/poplan-create/poplan-create.component';
import { SalesComponent } from './sales/sales.component';
import { ShipoutsComponent } from './sales/shipouts/shipouts.component';
import { SalesCreateComponent } from './sales/sales-create/sales-create.component';
import { SertanComponent } from './sales/sertan/sertan.component';
import { SoplanModalComponent } from './sales/soplan-modal/soplan-modal.component';
import { TxqohactualsComponent } from './inventory/txqohactuals/txqohactuals.component';
import { InventoryComponent } from './inventory/inventory.component';
import { SupplychainComponent } from './supplychain/supplychain.component';
import { SalesListComponent } from './sales/sales-list/sales-list.component';
import { TransitComponent } from './supplychain/transit/transit.component';
import { ReceivedComponent } from './supplychain/received/received.component';
import { SlottedComponent } from './sales/slotted/slotted.component';
import { PoplanDetailComponent } from './supplychain/poplan-detail/poplan-detail.component';
import { QuoteComponent } from './supplychain/quote/quote.component';
import { QuoteCreateComponent } from './supplychain/quote/quote-create/quote-create.component';
import { QuoteListComponent } from './supplychain/quote/quote-list/quote-list.component';
import { QuoteDetailComponent } from './supplychain/quote/quote-detail/quote-detail.component';
import { FinanceComponent } from './finance/finance.component';
import { ExpensesComponent } from './finance/expenses/expenses.component';



@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MemberListComponent,
    MemberDetailComponent,
    ListsComponent,
    MessagesComponent,
    TestErrorsComponent,
    NotFoundComponent,
    ServerErrorComponent,
    MemberCardComponent,
    MemberEditComponent,
    PhotoEditorComponent,
    TextInputComponent,
    DateInputComponent,
    MemberMessagesComponent,
    AdminPanelComponent,
    PhotoManagementComponent,
    UserManagementComponent,
    HasRoleDirective,
    RolesModalComponent,
    ConfirmDialogComponent,
    LandingComponent,
    TxqohComponent,
    TxqohCreateComponent,
    TxqohEditComponent,
    TxqohModalComponent,
    PurchaseordersComponent,
    PoplanModalComponent,
    PoplanCreateComponent,
    SalesComponent,
    ShipoutsComponent,
    SalesCreateComponent,
    SertanComponent,
    SoplanModalComponent,
    TxqohactualsComponent,
    InventoryComponent,
    SupplychainComponent,
    SalesListComponent,
    TransitComponent,
    ReceivedComponent,
    SlottedComponent,
    PoplanDetailComponent,
    QuoteComponent,
    QuoteCreateComponent,
    QuoteListComponent,
    QuoteDetailComponent,
    FinanceComponent,
    ExpensesComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatTableModule

  ],
  exports: [
    MatFormFieldModule,
    MatInputModule,
    MatHeaderRow
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
