namespace Trading
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.btn_dmm_login = new MaterialSkin.Controls.MaterialButton();
            this.btn_close = new MaterialSkin.Controls.MaterialButton();
            this.btn_sell = new MaterialSkin.Controls.MaterialButton();
            this.btn_buy = new MaterialSkin.Controls.MaterialButton();
            this.txt_dmm_username = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_dmm_passwd = new MaterialSkin.Controls.MaterialTextBox();
            this.panel_slow = new System.Windows.Forms.Panel();
            this.sw_real = new MaterialSkin.Controls.MaterialSwitch();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_fast_ask = new System.Windows.Forms.Label();
            this.lb_fast_bid = new System.Windows.Forms.Label();
            this.lb_lot = new System.Windows.Forms.Label();
            this.lb_symbol = new System.Windows.Forms.Label();
            this.btn_loading = new CircularProgressBar.CircularProgressBar();
            this.panel_fast = new System.Windows.Forms.Panel();
            this.cb_server = new MaterialSkin.Controls.MaterialComboBox();
            this.txt_mt_passwd = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_symbol_suffix = new MaterialSkin.Controls.MaterialTextBox();
            this.txt_mt_username = new MaterialSkin.Controls.MaterialTextBox();
            this.btn_mt_login = new MaterialSkin.Controls.MaterialButton();
            this.label2 = new System.Windows.Forms.Label();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_slow_bid = new System.Windows.Forms.Label();
            this.lb_slow_ask = new System.Windows.Forms.Label();
            this.btn_clear = new MaterialSkin.Controls.MaterialButton();
            this.lb_point = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_tp = new System.Windows.Forms.TextBox();
            this.tb_sl = new System.Windows.Forms.TextBox();
            this.tb_maxspread = new System.Windows.Forms.TextBox();
            this.tb_pricediff = new System.Windows.Forms.TextBox();
            this.btn_start = new MaterialSkin.Controls.MaterialButton();
            this.panel_slow.SuspendLayout();
            this.panel_fast.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_dmm_login
            // 
            this.btn_dmm_login.AutoSize = false;
            this.btn_dmm_login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_dmm_login.Depth = 0;
            this.btn_dmm_login.DrawShadows = true;
            this.btn_dmm_login.HighEmphasis = true;
            this.btn_dmm_login.Icon = null;
            this.btn_dmm_login.Location = new System.Drawing.Point(120, 204);
            this.btn_dmm_login.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_dmm_login.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_dmm_login.Name = "btn_dmm_login";
            this.btn_dmm_login.Size = new System.Drawing.Size(90, 50);
            this.btn_dmm_login.TabIndex = 2;
            this.btn_dmm_login.Text = "Login";
            this.btn_dmm_login.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_dmm_login.UseAccentColor = false;
            this.btn_dmm_login.UseVisualStyleBackColor = true;
            this.btn_dmm_login.Click += new System.EventHandler(this.btn_dmm_login_Click);
            // 
            // btn_close
            // 
            this.btn_close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_close.Depth = 0;
            this.btn_close.DrawShadows = true;
            this.btn_close.HighEmphasis = true;
            this.btn_close.Icon = null;
            this.btn_close.Location = new System.Drawing.Point(679, 606);
            this.btn_close.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_close.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(66, 36);
            this.btn_close.TabIndex = 5;
            this.btn_close.Text = "Close";
            this.btn_close.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_close.UseAccentColor = false;
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_sell
            // 
            this.btn_sell.AutoSize = false;
            this.btn_sell.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_sell.Depth = 0;
            this.btn_sell.DrawShadows = true;
            this.btn_sell.HighEmphasis = true;
            this.btn_sell.Icon = null;
            this.btn_sell.Location = new System.Drawing.Point(589, 606);
            this.btn_sell.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_sell.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_sell.Name = "btn_sell";
            this.btn_sell.Size = new System.Drawing.Size(66, 36);
            this.btn_sell.TabIndex = 3;
            this.btn_sell.Text = "SELL";
            this.btn_sell.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_sell.UseAccentColor = false;
            this.btn_sell.UseVisualStyleBackColor = true;
            this.btn_sell.Click += new System.EventHandler(this.btn_sell_Click);
            // 
            // btn_buy
            // 
            this.btn_buy.AutoSize = false;
            this.btn_buy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_buy.Depth = 0;
            this.btn_buy.DrawShadows = true;
            this.btn_buy.HighEmphasis = true;
            this.btn_buy.Icon = null;
            this.btn_buy.Location = new System.Drawing.Point(500, 606);
            this.btn_buy.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_buy.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_buy.Name = "btn_buy";
            this.btn_buy.Size = new System.Drawing.Size(66, 36);
            this.btn_buy.TabIndex = 4;
            this.btn_buy.Text = "BUY";
            this.btn_buy.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_buy.UseAccentColor = false;
            this.btn_buy.UseVisualStyleBackColor = true;
            this.btn_buy.Click += new System.EventHandler(this.btn_buy_Click);
            // 
            // txt_dmm_username
            // 
            this.txt_dmm_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dmm_username.Depth = 0;
            this.txt_dmm_username.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_dmm_username.Hint = "UserName";
            this.txt_dmm_username.Location = new System.Drawing.Point(10, 40);
            this.txt_dmm_username.MaxLength = 50;
            this.txt_dmm_username.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_dmm_username.Multiline = false;
            this.txt_dmm_username.Name = "txt_dmm_username";
            this.txt_dmm_username.Size = new System.Drawing.Size(200, 50);
            this.txt_dmm_username.TabIndex = 0;
            this.txt_dmm_username.Text = "v4928814";
            // 
            // txt_dmm_passwd
            // 
            this.txt_dmm_passwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_dmm_passwd.Depth = 0;
            this.txt_dmm_passwd.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_dmm_passwd.Hint = "Password";
            this.txt_dmm_passwd.Location = new System.Drawing.Point(10, 94);
            this.txt_dmm_passwd.MaxLength = 50;
            this.txt_dmm_passwd.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_dmm_passwd.Multiline = false;
            this.txt_dmm_passwd.Name = "txt_dmm_passwd";
            this.txt_dmm_passwd.Password = true;
            this.txt_dmm_passwd.Size = new System.Drawing.Size(200, 50);
            this.txt_dmm_passwd.TabIndex = 1;
            this.txt_dmm_passwd.Text = "fixapi777";
            // 
            // panel_slow
            // 
            this.panel_slow.Controls.Add(this.sw_real);
            this.panel_slow.Controls.Add(this.txt_dmm_passwd);
            this.panel_slow.Controls.Add(this.txt_dmm_username);
            this.panel_slow.Controls.Add(this.btn_dmm_login);
            this.panel_slow.Controls.Add(this.label1);
            this.panel_slow.Location = new System.Drawing.Point(255, 69);
            this.panel_slow.Name = "panel_slow";
            this.panel_slow.Size = new System.Drawing.Size(223, 271);
            this.panel_slow.TabIndex = 7;
            // 
            // sw_real
            // 
            this.sw_real.Checked = true;
            this.sw_real.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sw_real.Depth = 0;
            this.sw_real.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.sw_real.Location = new System.Drawing.Point(2, 157);
            this.sw_real.Margin = new System.Windows.Forms.Padding(0);
            this.sw_real.MouseLocation = new System.Drawing.Point(-1, -1);
            this.sw_real.MouseState = MaterialSkin.MouseState.HOVER;
            this.sw_real.Name = "sw_real";
            this.sw_real.Ripple = true;
            this.sw_real.Size = new System.Drawing.Size(138, 30);
            this.sw_real.TabIndex = 10;
            this.sw_real.Text = "Real/Demo";
            this.sw_real.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Slow Broker(DMM)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_fast_ask
            // 
            this.lb_fast_ask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_fast_ask.ForeColor = System.Drawing.Color.Lime;
            this.lb_fast_ask.Location = new System.Drawing.Point(637, 212);
            this.lb_fast_ask.Name = "lb_fast_ask";
            this.lb_fast_ask.Size = new System.Drawing.Size(100, 23);
            this.lb_fast_ask.TabIndex = 7;
            this.lb_fast_ask.Text = "N/A";
            this.lb_fast_ask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_fast_bid
            // 
            this.lb_fast_bid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_fast_bid.ForeColor = System.Drawing.Color.Lime;
            this.lb_fast_bid.Location = new System.Drawing.Point(506, 212);
            this.lb_fast_bid.Name = "lb_fast_bid";
            this.lb_fast_bid.Size = new System.Drawing.Size(100, 23);
            this.lb_fast_bid.TabIndex = 7;
            this.lb_fast_bid.Text = "N/A";
            this.lb_fast_bid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_lot
            // 
            this.lb_lot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_lot.ForeColor = System.Drawing.Color.Aquamarine;
            this.lb_lot.Location = new System.Drawing.Point(637, 137);
            this.lb_lot.Name = "lb_lot";
            this.lb_lot.Size = new System.Drawing.Size(100, 23);
            this.lb_lot.TabIndex = 7;
            this.lb_lot.Text = "N/A";
            this.lb_lot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_symbol
            // 
            this.lb_symbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_symbol.ForeColor = System.Drawing.Color.Aquamarine;
            this.lb_symbol.Location = new System.Drawing.Point(506, 137);
            this.lb_symbol.Name = "lb_symbol";
            this.lb_symbol.Size = new System.Drawing.Size(100, 23);
            this.lb_symbol.TabIndex = 7;
            this.lb_symbol.Text = "N/A";
            this.lb_symbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_loading
            // 
            this.btn_loading.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.btn_loading.AnimationSpeed = 500;
            this.btn_loading.BackColor = System.Drawing.Color.Transparent;
            this.btn_loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.btn_loading.ForeColor = System.Drawing.Color.Transparent;
            this.btn_loading.InnerColor = System.Drawing.Color.Transparent;
            this.btn_loading.InnerMargin = 2;
            this.btn_loading.InnerWidth = -1;
            this.btn_loading.Location = new System.Drawing.Point(728, 69);
            this.btn_loading.MarqueeAnimationSpeed = 2000;
            this.btn_loading.Name = "btn_loading";
            this.btn_loading.OuterColor = System.Drawing.Color.DarkGray;
            this.btn_loading.OuterMargin = -25;
            this.btn_loading.OuterWidth = 16;
            this.btn_loading.ProgressColor = System.Drawing.Color.DimGray;
            this.btn_loading.ProgressWidth = 8;
            this.btn_loading.RightToLeftLayout = true;
            this.btn_loading.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.btn_loading.Size = new System.Drawing.Size(35, 35);
            this.btn_loading.StartAngle = 270;
            this.btn_loading.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.btn_loading.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.btn_loading.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.btn_loading.SubscriptText = "";
            this.btn_loading.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.btn_loading.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.btn_loading.SuperscriptText = "";
            this.btn_loading.TabIndex = 2;
            this.btn_loading.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.btn_loading.Value = 65;
            this.btn_loading.Visible = false;
            // 
            // panel_fast
            // 
            this.panel_fast.Controls.Add(this.cb_server);
            this.panel_fast.Controls.Add(this.txt_mt_passwd);
            this.panel_fast.Controls.Add(this.txt_symbol_suffix);
            this.panel_fast.Controls.Add(this.txt_mt_username);
            this.panel_fast.Controls.Add(this.btn_mt_login);
            this.panel_fast.Controls.Add(this.label2);
            this.panel_fast.Location = new System.Drawing.Point(19, 69);
            this.panel_fast.Name = "panel_fast";
            this.panel_fast.Size = new System.Drawing.Size(223, 271);
            this.panel_fast.TabIndex = 7;
            // 
            // cb_server
            // 
            this.cb_server.AutoResize = false;
            this.cb_server.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cb_server.Depth = 0;
            this.cb_server.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cb_server.DropDownHeight = 174;
            this.cb_server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_server.DropDownWidth = 121;
            this.cb_server.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cb_server.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cb_server.FormattingEnabled = true;
            this.cb_server.IntegralHeight = false;
            this.cb_server.ItemHeight = 43;
            this.cb_server.Location = new System.Drawing.Point(11, 148);
            this.cb_server.MaxDropDownItems = 4;
            this.cb_server.MouseState = MaterialSkin.MouseState.OUT;
            this.cb_server.Name = "cb_server";
            this.cb_server.Size = new System.Drawing.Size(200, 49);
            this.cb_server.TabIndex = 10;
            this.cb_server.Visible = false;
            // 
            // txt_mt_passwd
            // 
            this.txt_mt_passwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_mt_passwd.Depth = 0;
            this.txt_mt_passwd.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_mt_passwd.Hint = "Password";
            this.txt_mt_passwd.Location = new System.Drawing.Point(11, 94);
            this.txt_mt_passwd.MaxLength = 50;
            this.txt_mt_passwd.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_mt_passwd.Multiline = false;
            this.txt_mt_passwd.Name = "txt_mt_passwd";
            this.txt_mt_passwd.Password = true;
            this.txt_mt_passwd.Size = new System.Drawing.Size(200, 50);
            this.txt_mt_passwd.TabIndex = 1;
            this.txt_mt_passwd.Text = "tvs528";
            // 
            // txt_symbol_suffix
            // 
            this.txt_symbol_suffix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_symbol_suffix.Depth = 0;
            this.txt_symbol_suffix.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_symbol_suffix.Hint = "Symbol Suffix";
            this.txt_symbol_suffix.Location = new System.Drawing.Point(11, 204);
            this.txt_symbol_suffix.MaxLength = 50;
            this.txt_symbol_suffix.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_symbol_suffix.Multiline = false;
            this.txt_symbol_suffix.Name = "txt_symbol_suffix";
            this.txt_symbol_suffix.Size = new System.Drawing.Size(100, 50);
            this.txt_symbol_suffix.TabIndex = 0;
            this.txt_symbol_suffix.Text = "oj5k";
            this.txt_symbol_suffix.Visible = false;
            this.txt_symbol_suffix.TextChanged += new System.EventHandler(this.txt_symbol_suffix_TextChanged);
            // 
            // txt_mt_username
            // 
            this.txt_mt_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_mt_username.Depth = 0;
            this.txt_mt_username.Font = new System.Drawing.Font("Roboto", 12F);
            this.txt_mt_username.Hint = "UserName";
            this.txt_mt_username.Location = new System.Drawing.Point(11, 40);
            this.txt_mt_username.MaxLength = 50;
            this.txt_mt_username.MouseState = MaterialSkin.MouseState.OUT;
            this.txt_mt_username.Multiline = false;
            this.txt_mt_username.Name = "txt_mt_username";
            this.txt_mt_username.Size = new System.Drawing.Size(200, 50);
            this.txt_mt_username.TabIndex = 0;
            this.txt_mt_username.Text = "213024376";
            // 
            // btn_mt_login
            // 
            this.btn_mt_login.AutoSize = false;
            this.btn_mt_login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_mt_login.Depth = 0;
            this.btn_mt_login.DrawShadows = true;
            this.btn_mt_login.HighEmphasis = true;
            this.btn_mt_login.Icon = null;
            this.btn_mt_login.Location = new System.Drawing.Point(121, 204);
            this.btn_mt_login.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_mt_login.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_mt_login.Name = "btn_mt_login";
            this.btn_mt_login.Size = new System.Drawing.Size(90, 50);
            this.btn_mt_login.TabIndex = 2;
            this.btn_mt_login.Text = "Login";
            this.btn_mt_login.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_mt_login.UseAccentColor = false;
            this.btn_mt_login.UseVisualStyleBackColor = true;
            this.btn_mt_login.Click += new System.EventHandler(this.btn_mt_login_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Fast Broker(GMO)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtb_log
            // 
            this.rtb_log.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.rtb_log.Location = new System.Drawing.Point(30, 346);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(437, 296);
            this.rtb_log.TabIndex = 8;
            this.rtb_log.Text = "";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.ForeColor = System.Drawing.Color.Aquamarine;
            this.label3.Location = new System.Drawing.Point(518, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Symbol / Lots";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label4.ForeColor = System.Drawing.Color.Lime;
            this.label4.Location = new System.Drawing.Point(518, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fast Bid / Ask";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(518, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "Slow Bid / Ask";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_slow_bid
            // 
            this.lb_slow_bid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_slow_bid.ForeColor = System.Drawing.Color.Red;
            this.lb_slow_bid.Location = new System.Drawing.Point(506, 281);
            this.lb_slow_bid.Name = "lb_slow_bid";
            this.lb_slow_bid.Size = new System.Drawing.Size(100, 23);
            this.lb_slow_bid.TabIndex = 7;
            this.lb_slow_bid.Text = "N/A";
            this.lb_slow_bid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_slow_ask
            // 
            this.lb_slow_ask.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lb_slow_ask.ForeColor = System.Drawing.Color.Red;
            this.lb_slow_ask.Location = new System.Drawing.Point(637, 281);
            this.lb_slow_ask.Name = "lb_slow_ask";
            this.lb_slow_ask.Size = new System.Drawing.Size(100, 23);
            this.lb_slow_ask.TabIndex = 7;
            this.lb_slow_ask.Text = "N/A";
            this.lb_slow_ask.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_clear
            // 
            this.btn_clear.AutoSize = false;
            this.btn_clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_clear.Depth = 0;
            this.btn_clear.DrawShadows = true;
            this.btn_clear.HighEmphasis = true;
            this.btn_clear.Icon = null;
            this.btn_clear.Location = new System.Drawing.Point(80, 595);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_clear.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(66, 36);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "Clear";
            this.btn_clear.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_clear.UseAccentColor = false;
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Visible = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // lb_point
            // 
            this.lb_point.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_point.ForeColor = System.Drawing.Color.White;
            this.lb_point.Location = new System.Drawing.Point(637, 346);
            this.lb_point.Name = "lb_point";
            this.lb_point.Size = new System.Drawing.Size(100, 23);
            this.lb_point.TabIndex = 7;
            this.lb_point.Text = "N/A";
            this.lb_point.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(506, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Point";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(506, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "TP";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(506, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 7;
            this.label8.Text = "SL";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(506, 464);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 7;
            this.label9.Text = "MaxSpread";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(506, 503);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.label10.TabIndex = 7;
            this.label10.Text = "PriceDiff";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_tp
            // 
            this.tb_tp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_tp.Location = new System.Drawing.Point(637, 383);
            this.tb_tp.Name = "tb_tp";
            this.tb_tp.Size = new System.Drawing.Size(100, 26);
            this.tb_tp.TabIndex = 9;
            this.tb_tp.Text = "0";
            this.tb_tp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_tp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_press);
            // 
            // tb_sl
            // 
            this.tb_sl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_sl.Location = new System.Drawing.Point(637, 422);
            this.tb_sl.Name = "tb_sl";
            this.tb_sl.Size = new System.Drawing.Size(100, 26);
            this.tb_sl.TabIndex = 9;
            this.tb_sl.Text = "0";
            this.tb_sl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_press);
            // 
            // tb_maxspread
            // 
            this.tb_maxspread.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_maxspread.Location = new System.Drawing.Point(637, 462);
            this.tb_maxspread.Name = "tb_maxspread";
            this.tb_maxspread.Size = new System.Drawing.Size(100, 26);
            this.tb_maxspread.TabIndex = 9;
            this.tb_maxspread.Text = "0";
            this.tb_maxspread.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_maxspread.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_press);
            // 
            // tb_pricediff
            // 
            this.tb_pricediff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tb_pricediff.Location = new System.Drawing.Point(637, 501);
            this.tb_pricediff.Name = "tb_pricediff";
            this.tb_pricediff.Size = new System.Drawing.Size(100, 26);
            this.tb_pricediff.TabIndex = 9;
            this.tb_pricediff.Text = "0";
            this.tb_pricediff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_pricediff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key_press);
            // 
            // btn_start
            // 
            this.btn_start.AutoSize = false;
            this.btn_start.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_start.Depth = 0;
            this.btn_start.DrawShadows = true;
            this.btn_start.HighEmphasis = true;
            this.btn_start.Icon = null;
            this.btn_start.Location = new System.Drawing.Point(500, 552);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_start.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(245, 36);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "Start Bot";
            this.btn_start.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btn_start.UseAccentColor = false;
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 661);
            this.Controls.Add(this.tb_pricediff);
            this.Controls.Add(this.tb_maxspread);
            this.Controls.Add(this.tb_sl);
            this.Controls.Add(this.tb_tp);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.lb_slow_ask);
            this.Controls.Add(this.lb_fast_ask);
            this.Controls.Add(this.panel_fast);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_buy);
            this.Controls.Add(this.lb_slow_bid);
            this.Controls.Add(this.lb_fast_bid);
            this.Controls.Add(this.btn_sell);
            this.Controls.Add(this.panel_slow);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_point);
            this.Controls.Add(this.lb_lot);
            this.Controls.Add(this.btn_loading);
            this.Controls.Add(this.lb_symbol);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrm";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arbitrage Bot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.panel_slow.ResumeLayout(false);
            this.panel_fast.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btn_dmm_login;
        private MaterialSkin.Controls.MaterialButton btn_close;
        private MaterialSkin.Controls.MaterialButton btn_sell;
        private MaterialSkin.Controls.MaterialButton btn_buy;
        private MaterialSkin.Controls.MaterialTextBox txt_dmm_username;
        private MaterialSkin.Controls.MaterialTextBox txt_dmm_passwd;
        private System.Windows.Forms.Panel panel_slow;
        private CircularProgressBar.CircularProgressBar btn_loading;
        private System.Windows.Forms.Label lb_fast_ask;
        private System.Windows.Forms.Label lb_fast_bid;
        private System.Windows.Forms.Label lb_lot;
        private System.Windows.Forms.Label lb_symbol;
        private System.Windows.Forms.Panel panel_fast;
        private MaterialSkin.Controls.MaterialTextBox txt_mt_passwd;
        private MaterialSkin.Controls.MaterialTextBox txt_mt_username;
        private MaterialSkin.Controls.MaterialButton btn_mt_login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_slow_bid;
        private System.Windows.Forms.Label lb_slow_ask;
        private MaterialSkin.Controls.MaterialButton btn_clear;
        private System.Windows.Forms.Label lb_point;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_tp;
        private System.Windows.Forms.TextBox tb_sl;
        private System.Windows.Forms.TextBox tb_maxspread;
        private System.Windows.Forms.TextBox tb_pricediff;
        private MaterialSkin.Controls.MaterialButton btn_start;
        private MaterialSkin.Controls.MaterialSwitch sw_real;
        private MaterialSkin.Controls.MaterialTextBox txt_symbol_suffix;
        private MaterialSkin.Controls.MaterialComboBox cb_server;
    }
}

