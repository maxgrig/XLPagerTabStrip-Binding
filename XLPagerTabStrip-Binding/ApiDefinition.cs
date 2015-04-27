using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace XLPagerTabStripBinding
{
    // @protocol XLPagerTabStripChildItem <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface XLPagerTabStripChildItem
    {
    	// @required -(NSString *)titleForPagerTabStripViewController:(XLPagerTabStripViewController *)pagerTabStripViewController;
    	[Abstract]
    	[Export ("titleForPagerTabStripViewController:")]
    	string TitleForPagerTabStripViewController (XLPagerTabStripViewController pagerTabStripViewController);

    	// @optional -(UIImage *)imageForPagerTabStripViewController:(XLPagerTabStripViewController *)pagerTabStripViewController;
    	[Export ("imageForPagerTabStripViewController:")]
    	UIImage ImageForPagerTabStripViewController (XLPagerTabStripViewController pagerTabStripViewController);

    	// @optional -(UIColor *)colorForPagerTabStripViewController:(XLPagerTabStripViewController *)pagerTabStripViewController;
    	[Export ("colorForPagerTabStripViewController:")]
    	UIColor ColorForPagerTabStripViewController (XLPagerTabStripViewController pagerTabStripViewController);
    }

    // @protocol XLPagerTabStripViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface XLPagerTabStripViewControllerDelegate
    {
    	// @optional -(void)pagerTabStripViewController:(XLPagerTabStripViewController *)pagerTabStripViewController updateIndicatorFromIndex:(NSInteger)fromIndex toIndex:(NSInteger)toIndex;
    	[Export ("pagerTabStripViewController:updateIndicatorFromIndex:toIndex:")]
    	void UpdateIndicatorFromIndex (XLPagerTabStripViewController pagerTabStripViewController, nint fromIndex, nint toIndex);

    	// @optional -(void)pagerTabStripViewController:(XLPagerTabStripViewController *)pagerTabStripViewController updateIndicatorFromIndex:(NSInteger)fromIndex toIndex:(NSInteger)toIndex withProgressPercentage:(CGFloat)progressPercentage;
    	[Export ("pagerTabStripViewController:updateIndicatorFromIndex:toIndex:withProgressPercentage:")]
    	void UpdateIndicatorFromIndex (XLPagerTabStripViewController pagerTabStripViewController, nint fromIndex, nint toIndex, nfloat progressPercentage);
    }

    // @protocol XLPagerTabStripViewControllerDataSource <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface XLPagerTabStripViewControllerDataSource
    {
    	// @required -(NSArray *)childViewControllersForPagerTabStripViewController:(XLPagerTabStripViewController *)pagerTabStripViewController;
//    	[Abstract]
    	[Export ("childViewControllersForPagerTabStripViewController:")]
    //	[Verify (StronglyTypedNSArray)]
    	NSObject[] ChildViewControllersForPagerTabStripViewController (XLPagerTabStripViewController pagerTabStripViewController);
    }

    // @interface XLPagerTabStripViewController : UIViewController <XLPagerTabStripViewControllerDelegate, XLPagerTabStripViewControllerDataSource, UIScrollViewDelegate>
    [Protocol]
    [BaseType (typeof(UIViewController))]
    interface XLPagerTabStripViewController : XLPagerTabStripViewControllerDelegate, XLPagerTabStripViewControllerDataSource, IUIScrollViewDelegate
    {
    	// @property (readonly) NSArray * pagerTabStripChildViewControllers;
    	[Export ("pagerTabStripChildViewControllers")]
    //	[Verify (StronglyTypedNSArray)]
    	NSObject[] PagerTabStripChildViewControllers { get; }

    	// @property (retain, nonatomic) UIScrollView * containerView;
    	[Export ("containerView", ArgumentSemantic.Retain)]
    	UIScrollView ContainerView { get; set; }

    	[Wrap ("WeakDelegate")]
    	XLPagerTabStripViewControllerDelegate Delegate { get; set; }

    	// @property (assign, nonatomic) id<XLPagerTabStripViewControllerDelegate> delegate;
    	[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
    	NSObject WeakDelegate { get; set; }

    	// @property (assign, nonatomic) id<XLPagerTabStripViewControllerDataSource> dataSource;
    	[Export ("dataSource", ArgumentSemantic.Assign)]
    	XLPagerTabStripViewControllerDataSource DataSource { get; set; }

    	// @property (readonly) NSUInteger currentIndex;
    	[Export ("currentIndex")]
    	nuint CurrentIndex { get; }

    	// @property BOOL skipIntermediateViewControllers;
    	[Export ("skipIntermediateViewControllers")]
    	bool SkipIntermediateViewControllers { get; set; }

    	// @property BOOL isProgressiveIndicator;
    	[Export ("isProgressiveIndicator")]
    	bool IsProgressiveIndicator { get; set; }

    	// @property BOOL isElasticIndicatorLimit;
    	[Export ("isElasticIndicatorLimit")]
    	bool IsElasticIndicatorLimit { get; set; }

    	// -(void)moveToViewControllerAtIndex:(NSUInteger)index;
    	[Export ("moveToViewControllerAtIndex:")]
    	void MoveToViewControllerAtIndex (nuint index);

    	// -(void)moveToViewController:(UIViewController *)viewController;
    	[Export ("moveToViewController:")]
    	void MoveToViewController (UIViewController viewController);

    	// -(void)reloadPagerTabStripView;
    	[Export ("reloadPagerTabStripView")]
    	void ReloadPagerTabStripView ();
    }

    // @interface XLButtonBarView : UICollectionView
    [Protocol]
    [BaseType (typeof(UICollectionView))]
    interface XLButtonBarView
    {
    	// @property (readonly, nonatomic) UIView * selectedBar;
    	[Export ("selectedBar")]
    	UIView SelectedBar { get; }

    	// @property UIFont * labelFont;
    	[Export ("labelFont", ArgumentSemantic.Assign)]
    	UIFont LabelFont { get; set; }

    	// @property NSUInteger leftRightMargin;
    	[Export ("leftRightMargin", ArgumentSemantic.Assign)]
    	nuint LeftRightMargin { get; set; }

    	// -(void)moveToIndex:(NSUInteger)index animated:(BOOL)animated swipeDirection:(XLPagerTabStripDirection)swipeDirection;
    	[Export ("moveToIndex:animated:swipeDirection:")]
    	void MoveToIndex (nuint index, bool animated, XLPagerTabStripDirection swipeDirection);

    	// -(void)moveFromIndex:(NSInteger)fromIndex toIndex:(NSInteger)toIndex withProgressPercentage:(CGFloat)progressPercentage;
    	[Export ("moveFromIndex:toIndex:withProgressPercentage:")]
    	void MoveFromIndex (nint fromIndex, nint toIndex, nfloat progressPercentage);
    }

    // @interface XLButtonBarPagerTabStripViewController : XLPagerTabStripViewController
    [Protocol]
    [BaseType (typeof(XLPagerTabStripViewController))]
    interface XLButtonBarPagerTabStripViewController
    {
    	// @property (readonly, nonatomic) XLButtonBarView * buttonBarView;
    	[Export ("buttonBarView")]
    	XLButtonBarView ButtonBarView { get; }
    }

}
