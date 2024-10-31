namespace supermarket_mene
{
    partial class utama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filteringProductAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortSellerAZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fIlteringSellerNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sellingFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortByAZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filteringItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageItemSellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.previewToolStripMenuItem,
            this.itemSellToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productFormToolStripMenuItem,
            this.categoryToolStripMenuItem,
            this.sellerToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.menuToolStripMenuItem.Text = "menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // productFormToolStripMenuItem
            // 
            this.productFormToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.productFormToolStripMenuItem.Name = "productFormToolStripMenuItem";
            this.productFormToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.productFormToolStripMenuItem.Text = "Category";
            this.productFormToolStripMenuItem.Click += new System.EventHandler(this.productFormToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.addToolStripMenuItem.Text = "Sort Category A-Z";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // categoryToolStripMenuItem
            // 
            this.categoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productReportToolStripMenuItem,
            this.filteringProductAddToolStripMenuItem});
            this.categoryToolStripMenuItem.Name = "categoryToolStripMenuItem";
            this.categoryToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.categoryToolStripMenuItem.Text = "Product";
            this.categoryToolStripMenuItem.Click += new System.EventHandler(this.categoryToolStripMenuItem_Click);
            // 
            // productReportToolStripMenuItem
            // 
            this.productReportToolStripMenuItem.Name = "productReportToolStripMenuItem";
            this.productReportToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.productReportToolStripMenuItem.Text = "Sort Product A-Z";
            this.productReportToolStripMenuItem.Click += new System.EventHandler(this.productReportToolStripMenuItem_Click);
            // 
            // filteringProductAddToolStripMenuItem
            // 
            this.filteringProductAddToolStripMenuItem.Name = "filteringProductAddToolStripMenuItem";
            this.filteringProductAddToolStripMenuItem.Size = new System.Drawing.Size(233, 26);
            this.filteringProductAddToolStripMenuItem.Text = "Filtering Product Add";
            this.filteringProductAddToolStripMenuItem.Click += new System.EventHandler(this.filteringProductAddToolStripMenuItem_Click);
            // 
            // sellerToolStripMenuItem
            // 
            this.sellerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortSellerAZToolStripMenuItem,
            this.fIlteringSellerNameToolStripMenuItem,
            this.sellingToolStripMenuItem});
            this.sellerToolStripMenuItem.Name = "sellerToolStripMenuItem";
            this.sellerToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sellerToolStripMenuItem.Text = "Seller";
            this.sellerToolStripMenuItem.Click += new System.EventHandler(this.sellerToolStripMenuItem_Click);
            // 
            // sortSellerAZToolStripMenuItem
            // 
            this.sortSellerAZToolStripMenuItem.Name = "sortSellerAZToolStripMenuItem";
            this.sortSellerAZToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sortSellerAZToolStripMenuItem.Text = "Sort Seller A-Z";
            this.sortSellerAZToolStripMenuItem.Click += new System.EventHandler(this.sortSellerAZToolStripMenuItem_Click);
            // 
            // fIlteringSellerNameToolStripMenuItem
            // 
            this.fIlteringSellerNameToolStripMenuItem.Name = "fIlteringSellerNameToolStripMenuItem";
            this.fIlteringSellerNameToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.fIlteringSellerNameToolStripMenuItem.Text = "Filtering SellerAge";
            this.fIlteringSellerNameToolStripMenuItem.Click += new System.EventHandler(this.fIlteringSellerNameToolStripMenuItem_Click);
            // 
            // sellingToolStripMenuItem
            // 
            this.sellingToolStripMenuItem.Name = "sellingToolStripMenuItem";
            this.sellingToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sellingToolStripMenuItem.Text = "SellerReport";
            this.sellingToolStripMenuItem.Click += new System.EventHandler(this.sellingToolStripMenuItem_Click);
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sellingFormToolStripMenuItem,
            this.itemLocationToolStripMenuItem});
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.previewToolStripMenuItem.Text = "Preview";
            // 
            // sellingFormToolStripMenuItem
            // 
            this.sellingFormToolStripMenuItem.Name = "sellingFormToolStripMenuItem";
            this.sellingFormToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.sellingFormToolStripMenuItem.Text = "Selling Form";
            this.sellingFormToolStripMenuItem.Click += new System.EventHandler(this.sellingFormToolStripMenuItem_Click);
            // 
            // itemLocationToolStripMenuItem
            // 
            this.itemLocationToolStripMenuItem.Name = "itemLocationToolStripMenuItem";
            this.itemLocationToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.itemLocationToolStripMenuItem.Text = "Item Location";
            this.itemLocationToolStripMenuItem.Click += new System.EventHandler(this.itemLocationToolStripMenuItem_Click);
            // 
            // itemSellToolStripMenuItem
            // 
            this.itemSellToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByAZToolStripMenuItem,
            this.filteringItemToolStripMenuItem,
            this.manageItemSellToolStripMenuItem});
            this.itemSellToolStripMenuItem.Name = "itemSellToolStripMenuItem";
            this.itemSellToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.itemSellToolStripMenuItem.Text = "ItemSell";
            // 
            // sortByAZToolStripMenuItem
            // 
            this.sortByAZToolStripMenuItem.Name = "sortByAZToolStripMenuItem";
            this.sortByAZToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.sortByAZToolStripMenuItem.Text = "sort by A-Z";
            this.sortByAZToolStripMenuItem.Click += new System.EventHandler(this.sortByAZToolStripMenuItem_Click);
            // 
            // filteringItemToolStripMenuItem
            // 
            this.filteringItemToolStripMenuItem.Name = "filteringItemToolStripMenuItem";
            this.filteringItemToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.filteringItemToolStripMenuItem.Text = "filtering item";
            this.filteringItemToolStripMenuItem.Click += new System.EventHandler(this.filteringItemToolStripMenuItem_Click);
            // 
            // manageItemSellToolStripMenuItem
            // 
            this.manageItemSellToolStripMenuItem.Name = "manageItemSellToolStripMenuItem";
            this.manageItemSellToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.manageItemSellToolStripMenuItem.Text = "Manage Item Sell";
            this.manageItemSellToolStripMenuItem.Click += new System.EventHandler(this.manageItemSellToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutProgramToolStripMenuItem});
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.logoutToolStripMenuItem.Text = "logout";
            // 
            // logoutProgramToolStripMenuItem
            // 
            this.logoutProgramToolStripMenuItem.Name = "logoutProgramToolStripMenuItem";
            this.logoutProgramToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.logoutProgramToolStripMenuItem.Text = "logout program";
            this.logoutProgramToolStripMenuItem.Click += new System.EventHandler(this.logoutProgramToolStripMenuItem_Click);
            // 
            // utama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "utama";
            this.Text = "utama";
            this.Load += new System.EventHandler(this.utama_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellingFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sellingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filteringProductAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortSellerAZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fIlteringSellerNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemSellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortByAZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filteringItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutProgramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageItemSellToolStripMenuItem;
    }
}