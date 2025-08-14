use EShopee;

create table users(
	UserId int not null,
    UserName varchar(30),
    UserEmail varchar(30),
    UserPassword varchar(30),
    UserAddress varchar(250),
    UserContact int,
    UserRole varchar(30),
    unique (UserId),
    primary key(UserId)
);

create table retailer(
	RetailerId int not null,
    RetailerName varchar(30),
    RetailerEmail varchar(30),
    RetailerPassword varchar(30),
    RetailerAddress varchar(250),
    RetailerContact int,
    unique (RetailerId),
    primary key (RetailerId)
);

create table product(
	ProductId int not null,
    ProductName varchar(30),
    ProductDescription varchar(250),
    ProductPrice int,
    ProductBrand varchar(30),
    ProductStock int,
    RetailerId int not null,
    unique (ProductId),
    primary key (ProductId),
    foreign key (RetailerId) references retailer(RetailerId)
);

create table productOrder(
	OrderId int not null,
    UserId int not null,
    OrderDate date,
    OrderAmount int,
    unique (OrderId),
    primary key (OrderId),
    foreign key (UserID) references users(UserId)
);

create table orderItem(
	OrderItemId int not null,
    UserId int not null,
    ProductId int not null,
    OrderItemQuantity int,
    OrderItemPrice int,
    unique (OrderItemId),
    primary key (OrderItemId),
    foreign key (UserId) references users(UserId),
    foreign key (ProductId) references product(ProductId)
);

create table cart(
	CartId int not null,
    UserId int not null,
    unique (CartId),
    primary key (CartId),
    foreign key (UserId) references users(UserId)
);

create table cartItem(
	CartItemId int not null,
    UserId int not null,
    ProductId int not null,
    CartItemQuantity int,
    unique (CartItemId),
    primary key (CartItemId),
    foreign key (UserId) references users(UserId),
    foreign key (ProductId) references product(ProductId)
);

create table wishlist(
	WishlistId int not null,
    UserId int not null,
    unique (WishlistId),
    primary key (WishlistId),
    foreign key (UserId) references users(UserId)
);

create table wishlistItem(
	WishlistItemId int not null,
    WishlistId int not null,
    ProductId int not null,
    unique (WishlistItemId),
    primary key (WishlistItemId),
    foreign key (ProductId) references product(ProductId),
    foreign key (WishlistId) references wishlist(WishlistId)    
);

