export class TreeNode {
    label: string;
    children?: TreeNode[];
    data?: any;
  
    constructor(label: string, children?: TreeNode[], data?: any) {
      this.label = label;
      this.children = children;
      this.data = data;
    }
  }
  